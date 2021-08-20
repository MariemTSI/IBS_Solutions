using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Tsi.Template.Core
{
    public class EngineContext
    { 
        public static Context Current { get; private set; }

        public static void Create()
        {
            Current = new (); 
        } 
    }

    public class Context
    {
        private readonly HashSet<Assembly> ApplicationAssemblies = new();

        private IServiceProvider ServicesProvider { get; set; }


        public Type ContextType { get; set; }

        public void SetupServiceProvider(IServiceProvider serviceProvider)
        {
            ServicesProvider = serviceProvider;
        }

        public void LoadAssembly(Type type)
        {
            if (!ApplicationAssemblies.Contains(type.Assembly))
            {
                ApplicationAssemblies.Add(type.Assembly);
            } 
        }

        public IEnumerable<Assembly> GetAssemblies()
        {
            foreach (Assembly assembly in ApplicationAssemblies)
            {
                yield return assembly;
            }
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        } 

        public object Resolve(Type type)
        {
            return GetServiceProvider().GetService(type);
        }
        public virtual IEnumerable<T> ResolveAll<T>()
        { 
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

        protected IServiceProvider GetServiceProvider(IServiceScope scope = null)
        {
            if (scope == null)
            {
                var accessor = ServicesProvider?.GetService<IHttpContextAccessor>();
                var context = accessor?.HttpContext;
                return context?.RequestServices ?? ServicesProvider;
            }
            return scope.ServiceProvider;
        }

        public virtual IEnumerable<Type> FindAllTypes<T>()
        {
            return FindAllTypes(typeof(T));
        }

        private IEnumerable<Type> FindAllTypes(Type assignTypeFrom, bool onlyConcreteClasses = true)
        {
            var result = new List<Type>();
            try
            {
                foreach (var a in GetAssemblies())
                {
                    Type[] types = null;
                    try
                    {
                        types = a.GetTypes();
                    }
                    catch
                    {
                        //Entity Framework 6 doesn't allow getting types (throws an exception) 
                    }

                    if (types == null)
                        continue;

                    foreach (var t in types)
                    {
                        if (!assignTypeFrom.IsAssignableFrom(t) && (!assignTypeFrom.IsGenericTypeDefinition || !DoesTypeImplementOpenGeneric(t, assignTypeFrom)))
                            continue;

                        if (t.IsInterface)
                            continue;

                        if (onlyConcreteClasses)
                        {
                            if (t.IsClass && !t.IsAbstract)
                            {
                                result.Add(t);
                            }
                        }
                        else
                        {
                            result.Add(t);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var msg = string.Empty;
                foreach (var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;

                var fail = new Exception(msg, ex);
                Debug.WriteLine(fail.Message, fail);

                throw fail;
            }

            return result;
        }

        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    if (genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition()))
                        return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
