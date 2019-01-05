using System;

namespace EvgenySaveliev.Utils
{
    /// <summary>
    /// <para>A static CPU Utilities class that allows getting the number of CPU physical and logical cores available.</para>
    /// <para>SystemException is thrown if for any reason ManagementObjectSearcher("Select NumberOfCores from Win32_Processor") query returns zero physical cores.</para>
    /// </summary>
    /// <exception cref="SystemException"></exception>
    public class CpuUtils
    {
        static CpuUtils()
        {
            ObtainPhysicalCoreCount();
            ObtainLogicalCoreCount();
        }

        /// <summary>
        /// Gets the number of physical CPU cores available.
        /// </summary>
        public static int PhysicalCoreCount
        {
            get; private set;
        }

        /// <summary>
        /// Gets the number of logical CPU cores available.
        /// </summary>
        public static int LogicalCoreCount
        {
            get; private set;
        }

        private static void ObtainPhysicalCoreCount()
        {
            int coreCount = 0;

            foreach (var item in new System.Management.ManagementObjectSearcher("Select NumberOfCores from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }

            if (coreCount == 0)
                throw new SystemException("Couldn't get physical core count.");

            PhysicalCoreCount = coreCount;
        }

        private static void ObtainLogicalCoreCount()
        {
            LogicalCoreCount = Environment.ProcessorCount;
        }
    }
}
