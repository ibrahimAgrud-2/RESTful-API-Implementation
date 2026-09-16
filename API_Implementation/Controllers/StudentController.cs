using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_Implementation.Controllers
{
    //Genel API URL'inde API/Students olarak gözükecek.
    [Route("api/Students")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        //Bu da tamamen çalışır ama 2.yöntem daha profesyoneldir.
        //Çünkü bu yöntemde status code'u geri dönerme gibi bir şansımız yok.
        //mesela üstüden listesi boşsa notFound, veya client'in izni yoksa 
        //Forbidden gibi status dönderebilmek için action result kullanmalıyız
        //[HttpGet]
        //public List<Student> GetStudentList()
        //{
        //    return StudentDataSimulation.StudentList;
        //}


        //Yukarda açıkladığımız sebepten ötürü veri döndereceğin zaman ActionResult ile döndermelisin
        //Action Result geriye veriyi ve o request'in status code'unu action result kutusu içinde gönderir kodu dönderir  
        //IEnumarable ise client kısmı için list, array, dictionary fark etmeyeceği, onu sadece JSON formatında veri alacağı için hangi türden veri döndürdüğümüzün pek önemi yok. Daha doğrusu sadeec List<Student> demek yerine durumu daha geneleştiriyoruz. IEnumarable<student> diyoruz. IEnumarable zaten list'in daha geniş halidir. Bu durumda biz geriye bir koleksiyon döncekek. Ne olduğu pek önemli diğer onu al ve JSON olarak istediğini yap şeklinde düşünüyoruz.
        //!!!! Arka planda ASP framework JSON serialization ile veriyi JSON'a çeviriyor
        [HttpGet("All")]
        public ActionResult<IEnumerable<Student>> GetStudentList()
        {
            return Ok(StudentDataSimulation.StudentList);
        }



        //isimlendirmeler ile (all, passed) attriburte'lar birbirinden farklı olmuş oldu. Ama daha okunaklı URL'lere adına Attrüburlara her zaman değişkenlerde olduğu gibi alakalı isim vermek gerekir.


        [HttpGet("Passed")]
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            return Ok(StudentDataSimulation.StudentList.Where(student=>student.Grade>50).ToList());
        }

    }
}
