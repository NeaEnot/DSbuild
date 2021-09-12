using DS1core.Models;
using System.Collections.Generic;

namespace DS1downloader.DownloadSchemas
{
    internal interface ISchema
    {
        List<Entity> Download();
    }
}
