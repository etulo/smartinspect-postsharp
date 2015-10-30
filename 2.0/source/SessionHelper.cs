/**
 * Copyright Gurock Software GmbH. All rights reserved.
 * http://www.gurock.com - contact@gurock.com
 *
 * Learn more about the SmartInspect for PostSharp aspects on
 * the following project website:
 *
 * http://code.gurock.com/p/smartinspect-postsharp/
 */

using System.Reflection;
using PostSharp.Reflection;

namespace Gurock.SmartInspect.PostSharp
{
	static class SessionHelper
	{
		public static Session GetSession(string name)
		{
			Session session = SiAuto.Si.GetSession(name);

			if (session == null)
			{
				session = SiAuto.Si.AddSession(name, true);
			}

			return session;
		}

		public static string GetName(SessionPolicy policy, MemberInfo memberInfo, string customName)
		{
			switch (policy)
			{
				case SessionPolicy.Custom:
					if (customName != null)
					{
						return customName;
					}
					else 
					{
						return SiAuto.Main.Name;
					}

				case SessionPolicy.TypeName:
					return memberInfo.DeclaringType.Name;

				case SessionPolicy.FullyQualifiedTypeName:
					return memberInfo.DeclaringType.Namespace + "." + memberInfo.DeclaringType.Name;

				case SessionPolicy.Namespace:
					return memberInfo.DeclaringType.Namespace;
                case SessionPolicy.MemberName:
                    return memberInfo.Name;
            }

			return SiAuto.Main.Name;
		}

        public static string GetName(SessionPolicy policy, LocationInfo locationInfo, string customName)
        {
            switch (policy)
            {
                case SessionPolicy.Custom:
                    if (customName != null)
                    {
                        return customName;
                    }
                    else
                    {
                        return SiAuto.Main.Name;
                    }

                case SessionPolicy.TypeName:
                    return locationInfo.DeclaringType.Name;

                case SessionPolicy.FullyQualifiedTypeName:
                    return locationInfo.DeclaringType.Namespace + "." + locationInfo.DeclaringType.Name;

                case SessionPolicy.Namespace:
                    return locationInfo.DeclaringType.Namespace;
                case SessionPolicy.MemberName:
                    return locationInfo.Name;
            }

            return SiAuto.Main.Name;
        }
    }
}
