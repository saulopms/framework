using Microsoft.AspNetCore.Http;

namespace Base.Repository.Utils {
    public class UrlUtils {
        public static string FromUri (HttpRequest request, long id) {
            return request.Path + "/" + id;
        }
    }
}