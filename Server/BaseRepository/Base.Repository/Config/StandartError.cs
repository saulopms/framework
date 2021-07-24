using System.Text.Json;

namespace Base.Repository.ExceptionUtils
{
    public class StandartError {

        public int Status { get; set; }
        public string Error { get; set; }

        public StandartError (int status, string Error) {
            this.Status = status;
            this.Error = Error;
        }
        
        public override string ToString()  
        {  
            return JsonSerializer.Serialize(this);  
        }  
    }
}