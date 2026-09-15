using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_Implementation.Controllers
{
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
        //IEnumarable ise client kısmı için list, array, dictionary fark etmeyeceği, onu sadece JSON formatında veri alacağı için hangi türden veri döndürdüğümüzün pek önemi yok. Daha doğrusu sadeec List<Student> demek yerine durumu daha geneleştiriyoruz. IEnumarable<student> diyoruz. IEnumarable zaten list'in daha genil halidir. Bu durumda biz geriye bir koleksiyon döncekek. Ne olduğu pek önemli diğer onu al ve JSON olarak istediğini yap
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudentList()
        {
            return Ok(StudentDataSimulation.StudentList);
        }


    }
}
