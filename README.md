# ConnectApiCupomMarketing
Exemplo de consumo da API Cupom Marketing em ASP.NET MVC C# 

 Nesse projeto foi criado uma classe "ConsumingAPI.cs" com 2 métodos assíncronos para fazer as chamadas Post e Get. 
   
      
      public static async Task<string> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var result = await client.GetAsync("");
                string data = await result.Content.ReadAsStringAsync();
                return data;
            }

         }                   
             
           
       public static async Task<string> Post(string url, Object obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage data = await client.PostAsJsonAsync("", obj);
                return await data.Content.ReadAsStringAsync();
            }

        }

Na classe "ExemploController.cs" está o exemplo para os valores das requisições.

           
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
        
Classes POCO criadas:
        
    public class ListaCupons
     {
        public string name_coupon { get; set; }
        public string quantity { get; set; }
        public string end_date { get; set; }
        public string discount { get; set; }
        public string id_coupon { get; set; }
     }
     
    public class ListaResgates
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string date { get; set; }
        public string name_coupon { get; set; }
        public string code_coupon { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
    }
    
    public class ListaValidacoes
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string date { get; set; }
        public string name_coupon { get; set; }
        public string code_coupon { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
    }
    
    public class ResgatarCupom
    {
        public string code_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string id_coupon { get; set; }
    }
    
    public class ResultPostResgataCupom
    {
        public string code_coupon { get; set; }
        public string end_date { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }
    
    public class ResultPostValidaCupom
    {
        public string message { get; set; }
        public string result { get; set; }
    }
    
    public class ResumoCupom
    {
        public string description { get; set; }
        public string discount { get; set; }
        public string customer_name { get; set; }
    }
    
    public class ValidarCupom
    {
        public string code_id { get; set; }
        public string code_coupon { get; set; }
    }


<h1>Documentação geral da API Cupom Marketing V1</h1>

<h2>Atenção</h2>
Para algumas as requisições será preciso que você forneça seu código de identificação<strong> code_id</strong>, não compartilhe esse com ninguém e mantenha em lugar seguro.



<h1><strong>1. Listar todas as campanhas de cupons:</strong></h1>

<h2>GET</h2>
  http://apilive.cupommarketing.com/api-v1/coupons/code_id<br/>
  
 <br/> 
EXEMPLO DE RESPOSTA:

200

Content-Type:application/json


                             [ 
                                {
                                  "name_coupon": "50% OFF  em peças de roupas ",
                                   "quantity": "20000",
                                   "end_date": "16/02/2017",
                                   "discount": "50",
                                   "id_coupon": "d59bb51d1326432a82606175b7e10589"
                                },

                         
                                {
                                   "name_coupon": "Cupom Leve 1 e pague 2 Combo família",
                                   "quantity": "9",
                                   "end_date": "27/01/2017",
                                   "discount": "10",
                                   "id_coupon": "32ea907d5c4a40d0beab8e3f3ff26830"
                                }
                             ]
                            

<h1>2. Listar todos os resgates dos cupons:</h1>

<h2>GET</h2>
http://apilive.cupommarketing.com/api-v1/rescue/code_id

<br/>
EXEMPLO DE RESPOSTA:

200

Content-Type:application/json


                             [ 
                                {
                                    "name": "monica",
                                    "email": "null",
                                    "phone": "021999888589",
                                    "date": "10/02/2017",
                                    "name_coupon": "50% de desconto em toda a loja ",
                                    "code_coupon": "855204a4",
                                    "ip": "203.29.999.99",
                                    "mac": "485A39386F79"
                                },

                                {
                                    "name": "vera",
                                    "email": "vara@exemplo12mkt.com",
                                    "phone": "null",
                                    "date": "10/02/2017",
                                    "name_coupon": "10% de desconto em toda a loja",
                                    "code_coupon": "69380e6f",
                                    "ip": "202.29.999.99",
                                    "mac": "410A39536F79"
                                },

                                {
                                    "name": "João",
                                    "email": "joao@exemplo12mkt.com",
                                    "phone": "21969222222",
                                    "date": "10/02/2017",
                                    "name_coupon": "25% de desconto em produtos naturais",
                                    "code_coupon": "69380e9f",
                                    "ip": "201.29.999.99",
                                    "mac": "417A39536F78"
                                }

                             ]
                            

<h1>3. Gerando um código de cupom e fazendo o resgate.</h1>

Os parâmetros email e phone são importantes para você popular a sua base de dados e trabalhar posteriormente com a sua lista de contatos.

"code_id" - Preenchimento <strong>obrigatório</strong>, seu código de identificação.

"name" - Tamanho máximo de caracteres 25, preenchimento <strong>obrigatório</strong>.

"phone" - Tamanho máximo de caracteres 11, o preenchimento pode ser vazio.

"email" - Tamanho máximo de caracteres 50, o preenchimento pode ser vazio.

"id_coupon" - Preenchimento <strong>obrigatório</strong>, para pegar esse id_coupon, é necessário listar suas campanhas de cupons. Você deve escolher a campanha que deseja resgatar o cupom e gerar um código de desconto.


<h2>POST</h2>
http://apilive.cupommarketing.com/api-v1/getcoupon

<br/>
EXEMPLO DE REQUISÇÃO:

BODY


                                {
                                   "code_id":"MKTe0d25714a0000",
                                   "name":"maria",
                                   "phone":"02199955588",
                                   "email":"exemplo@exemplo.com",
                                   "id_coupon":"07p1b826c9a94688a5251d171ea594f2"
                                }


                            

EXEMPLO DE RESPOSTA:

200

Content-Type:application/json


                             [ 
                                {
                                  "code_coupon": "28b4cd69",
                                  "end_date": "28/02/2017",
                                  "message": "Resgate de código realizado com sucesso",
                                  "result": "1"                               
                                }
                             ]
                            

O parâmetro message apresenta uma mensagem indicando se seu resgate foi realizado com sucesso, mas caso o resgate não seja efetuado o retorno pode apresentar as seguintes mensagens:

"message": "Cupom expirado"

"message": "A quantidade de cupom acabou"

O parâmetro result retorna 1 ou 0 sendo 1 sucesso e 0 falha.


<h1>4. Listar todas as validações dos cupons:</h1>

<h2>GET</h2>
http://apilive.cupommarketing.com/api-v1/validation/code_id
<br/>

EXEMPLO DE RESPOSTA:

200

Content-Type:application/json


                             [ 
                                {
                                  "name": "Fernanda",
                                  "email": "null",
                                  "phone": "021999888589",
                                  "date": "11/02/2017",
                                  "name_coupon": "50% de desconto em toda a loja ",
                                  "code_coupon": "405200a4",
                                  "ip": "178.999.75.2",
                                  "mac": "487A40386F79"
                                },

                                {
                                  "name": "maria",
                                  "email": "maria@exemplo12mkt.com",
                                  "phone": "null",
                                  "date": "11/02/2017",
                                  "name_coupon": "40% de desconto em toda a loja",
                                  "code_coupon": "17380e8f",
                                  "ip": "177.29.999.99",
                                  "mac": "210A39536F79"
                                },

                                {
                                  "name": "maria",
                                  "email": "maria@exemplo12mkt.com",
                                  "phone": "21999111999",
                                  "date": "11/02/2017",
                                  "name_coupon": "40% de desconto em toda a loja",
                                  "code_coupon": "39381e8f",
                                  "ip": "208.29.999.99",
                                  "mac": "810A39536F79"
                               }

                             ]
                            

<h1>5. Exibir um resumo do cupom:</h1>

<strong>code_coupon</strong> – é o código do cupom de desconto.


<h2>GET</h2>
http://apilive.cupommarketing.com/api-v1/couponsummary/code_coupon
<br/>

EXEMPLO DE RESPOSTA:

200

Content-Type:application/json


                             [ 
                                {
                                 "description": "25% em todo o site",
                                 "discount": "25",
                                 "customer_name": "Marcelo"
                                }
                             ]
                            

<h1>6. Validar um cupom de desconto:</h1>

"code_id" - Preenchimento <strong>obrigatório</strong>, seu código de identificação.

"code_coupon " - Preenchimento <strong>obrigatório</strong>, código do cupom de desconto.


<h2>POST</h2>
http://apilive.cupommarketing.com/api-v1/validationcoupon
<br/>
EXEMPLO DE REQUISÇÃO:

BODY


                              {
                               "code_id":" MKTe0d25714a0000",
                               "code_coupon":"28b4cd69"
                              }

                            

EXEMPLO DE RESPOSTA:

200

Content-Type:application/json


                             [ 
                                
                                {
                                  "message": "Resgate de código realizado com sucesso",
                                  "result": "1"
                                }
                             ]
                            

O parâmetro message apresenta uma mensagem indicando se sua validação foi realizada com sucesso, mas caso a validação não seja efetuada o retorno pode apresentar as seguintes mensagens:

"message": "Esse cupom já foi validado"

"message ": "Esse cupom não foi criado por você"

"message ": "Cupom expirado"

O parâmetro result retorna 1 ou 0 sendo 1 sucesso e 0 falha.
