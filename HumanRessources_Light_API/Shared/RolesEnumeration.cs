namespace HumanRessources_Light_API.Shared
{
    /// <summary>
    ///     The roles existing in the system
    /// </summary>
    public enum RolesEnum
    {
        Administrator,
        Employee,
        None
    }

    /// <summary>
    /// Helper class for RolesEnum conversions
    /// </summary>
    public static class RolesEnumConverter
    {

        /// <summary>
        ///     Converts a RolesEnum value to its equivalent string
        /// </summary>
        /// <param name="rolesEnum"> the RolesEnum itself </param>
        /// <returns> string value </returns>
        public static string ToString(this RolesEnum rolesEnum)
        {
            return rolesEnum switch
            {
                RolesEnum.Administrator => "Administrator",
                RolesEnum.Employee => "Employee",
                _ => "",
            };
        }

        /// <summary>
        ///     Converts a role string to its equivalent RolesEnum
        /// </summary>
        /// <param name="role"> string value </param>
        /// <returns> RolesEnum value </returns>
        public static RolesEnum ToRolesEnum(string role)
        {
            return role switch
            {
                "Administrator" => RolesEnum.Administrator,
                "Employee" => RolesEnum.Employee,
                _ => RolesEnum.None
            };
        }
    }
}
