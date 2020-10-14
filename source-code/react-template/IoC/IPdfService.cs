using react_template_data.Data.Master;

namespace react_template.IoC
{
    public interface IPdfService
    {
        public byte[] Generate(string html, Style styles);
    }
}
