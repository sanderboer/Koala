using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace KoalaResults
{
    public class KoalaResultsInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "KoalaResults";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "Koala Results components for analyzing SCIA Engineer calculation results";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("2be88fcc-c338-4446-b4ef-93477d5796c1");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Developed for SCIA by Strawberrylab";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "support@scia.net";
            }
        }
    }
}
