﻿using System;
using System.Reflection;

namespace WebGameBacklog.Shared.Persistence
{
       public static class UnitOfWorkHelper
   {
       public static bool IsRepositoryMethod(MethodInfo methodInfo)
       {
           return IsRepositoryClass(methodInfo.DeclaringType);
       }
 
       public static bool IsRepositoryClass(Type type)
       {
           return typeof(IRepository<>).IsAssignableFrom(type);
       }
 
       public static bool HasUnitOfWorkAttribute(MethodInfo methodInfo)
       {
           return methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
       }
   }
}
