using System;
using System.Net;
using Base.Repository.ExceptionUtils;

namespace Base.Repository.Utils
{
    public class DateUtils  
    {   
        public static DateTime? Parse(string data){
            try{
                if(data != null && !data.Equals("")){
                    var partsData = data.Split(' ');
                    bool hasHorario =partsData.Length > 1;
                    var parts = data.Split('/');
                    if(hasHorario){
                        parts = partsData[0].Split('/');
                    }
                    var dia = Int32.Parse(parts[0]);
                    var mes = Int32.Parse(parts[1]);
                    var ano = Int32.Parse(parts[2]);
                    if(hasHorario){
                        var horario = partsData[1];
                        var partsHora = horario.Split(':');
                        var hora = Int32.Parse(partsHora[0]);
                        var minutos = Int32.Parse(partsHora[1]);
                        var segundos = Int32.Parse(partsHora[2]);
                        return new DateTime(ano, mes, dia, hora,minutos,segundos);
                    }
                    return new DateTime(ano, mes, dia, 0,0,0);
                }
                return null; 
            }catch(Exception err){
                throw new CustomException("Formato de data inválido, o formato deve ser dd/MM/yyyy ou dd/MM/yyyy HH:mm:ss", HttpStatusCode.BadRequest);
            }  
        }

        public static string ConvertBrFormatString(string data){
            try{
                if(!data.Equals(null) && !data.Equals("")){
                    var parts = data.Split(' ');
                    var hasHora = parts.Length > 1;
                    var partData = parts[0].Split('/');
                    if(hasHora){
                        var partHora = parts[1].Split(':');
                        var dataFormatada = partData[2] + "-" + partData[1] + "-" + partData[0] + " " + partHora[0] + ":" + partHora[1] + ":" + partHora[2];
                        return dataFormatada;  
                    }
                    var dataFormatada2 = partData[2] + "-" + partData[1] + "-" + partData[0] + " 00:00:00";
                    return dataFormatada2;
                }
                return "";
            }catch(Exception err){
                throw new CustomException("Formato de data inválido, o formato deve ser dd/MM/yyyy ou dd/MM/yyyy HH:mm:ss", HttpStatusCode.BadRequest);
            }
        }
    }
}