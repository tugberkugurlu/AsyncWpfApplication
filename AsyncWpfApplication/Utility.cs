using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AsyncWpfApplication {

    public class Utility {

        public static string FormatHeaders(WebHeaderCollection headers) {

            var headerStrings = from header in headers.Keys.Cast<string>()
                                select string.Format("{0}: {1}", header, headers[header]);

            return string.Join(Environment.NewLine, headerStrings.ToArray());

        }

    }
}
