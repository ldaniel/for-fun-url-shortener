using System;

namespace URLShortener.Models
{
    public class URL
    {
        public String Original { get; set; }
        public String Id { get; set; }
        public DateTime Created { get; set; }
        public String CreatedBy { get; set; }
        public Int32 Hits { get; set; }
        public Status Status { get; set; }

        public URL() { }

        public bool IsWellFormedUriString()
        {
            // TODO: Checar o que é melhor, relative or absolute.
            return Uri.IsWellFormedUriString(Original, UriKind.RelativeOrAbsolute);
        }
    }

    public enum Status
    {
        Null,
        AliasExists,
        URLExists,
        NewURL
    }
}