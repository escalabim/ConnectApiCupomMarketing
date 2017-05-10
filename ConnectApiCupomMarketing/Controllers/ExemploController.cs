using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using ConectApiCupomMarketing.Models;

namespace ConectApiCupomMarketing.Controllers
{
    public class ExemploController : Controller
    {
        const string code_id = "SEU code_id aqui";


        // GET: / Listar todas as campanhas de cupons
        public async Task<ActionResult> ListarCoupons()
        {
            string Valores = string.Empty;
            string result = await ConsumingAPI.Get(string.Format("http://apilive.cupommarketing.com/api-v1/coupons/{0}", code_id));
            List<ListaCupons> ListValues = new JavaScriptSerializer().Deserialize<List<ListaCupons>>(result);

            //foreach (var item in ListValues)
            //{
            //    item.name_coupon;
            //    item.quantity;
            //    item.discount;
            //    item.id_coupon;
            //}

            return View();
        }

        // GET: / Listar todos os resgates de cupons:
        public async Task<ActionResult> ListarResgates()
        {
            string Valores = string.Empty;
            string result = await ConsumingAPI.Get(string.Format("http://apilive.cupommarketing.com/api-v1/rescue/{0}", code_id));
            List<ListaResgates> ListValues = new JavaScriptSerializer().Deserialize<List<ListaResgates>>(result);


            //foreach (var item in ListValues)
            //{
            //    item.name;
            //    item.email;
            //    item.phone;
            //    item.date;
            //    item.name_coupon;
            //    item.code_coupon;
            //    item.ip;
            //    item.mac;
            //}

            return View();
        }


        // GET: / Listar todas as validações:
        public async Task<ActionResult> ListarValidacoes()
        {
            string Valores = string.Empty;
            string result = await ConsumingAPI.Get(string.Format("http://apilive.cupommarketing.com/api-v1/validation/{0}", code_id));
            List<ListaValidacoes> ListValues = new JavaScriptSerializer().Deserialize<List<ListaValidacoes>>(result);


            //foreach (var item in ListValues)
            //{
            //    item.name;
            //    item.email;
            //    item.phone;
            //    item.date;
            //    item.name_coupon;
            //    item.code_coupon;
            //    item.ip;
            //    item.mac;
            //}

            return View();
        }

        // POST: / Gerar um código de cupom fazendo oresgate:
        public async Task<ActionResult> ResgatarCupom()
        {
            ResgatarCupom Reg = new ResgatarCupom();

            Reg.code_id = code_id;
            Reg.email = "";    // opcional  
            Reg.phone = "";    // opcional 
            Reg.name = "";        // obrigatório
            Reg.id_coupon = "";  //  obrigatório, você deve pegar esse valor na listagem de cupons.

            string result = await ConsumingAPI.Post("http://apilive.cupommarketing.com/api-v1/getcoupon", Reg);
            List<ResultPostResgataCupom> ListValues = new JavaScriptSerializer().Deserialize<List<ResultPostResgataCupom>>(result);

            //foreach (var item in ListValues)
            //{
            //    //  item.message;
            //    //  item.result;
            //    //  item.end_date;

            //}

            return View();
        }

        // GET: / Exibir um resumo do cupom, não é necessario passar o code_id
        public async Task<ActionResult> ResumoCupom()
        {

            string CodigoCupomDesconto = ""; // Você deve passar o codigo do cupom de desconto;

            string result = await ConsumingAPI.Get(string.Format("http://apilive.cupommarketing.com/api-v1/couponsummary/{0}",CodigoCupomDesconto));
            List<ResumoCupom> ListValues = new JavaScriptSerializer().Deserialize<List<ResumoCupom>>(result);


            //foreach (var item in ListValues)
            //{
            //    item.description;
            //    item.discount;
            //    item.customer_name;
            //}

            return View();
        }

        // POST: / Valida um cupom de desconto:
        public async Task<ActionResult> ValidaCupom()
        {
            ValidarCupom Val = new ValidarCupom();

            Val.code_id = code_id;
            Val.code_coupon = "";  //  obrigatório, você deve passar o código do cupom para validar.

            string result = await ConsumingAPI.Post("http://apilive.cupommarketing.com/api-v1/validationcoupon", Val);
            List<ResultPostValidaCupom> ListValues = new JavaScriptSerializer().Deserialize<List<ResultPostValidaCupom>>(result);

            //foreach (var item in ListValues)
            //{
            //    item.message;
            //    item.result;

            //}

            return View();
        }



    }
}