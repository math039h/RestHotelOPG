using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLib.model;
using Newtonsoft.Json;

namespace ClassDemoRestConsumer
{
    internal class Worker
    {
            private const string URI = "http://localhost:50935/api/Facilitet";
            public Worker()
            {
                // THIS IS TEST COMMIT STUFF
            }

            public void Start()
            {
                List<Facilitet> facilitets = GetAll();

                foreach (var hotel in facilitets)
                {
                    Console.WriteLine("Facilitet:: " + hotel.Name);
                }

                Console.WriteLine("Henter nummer 2");
                Console.WriteLine("Facilitet :: " + GetOne(2));


                Console.WriteLine("Sletter nummer 2");
                Console.WriteLine("Resultat = " + Delete(2));

                Console.WriteLine("Opretter et nyt Facilitet object, id findes ");
                Console.WriteLine("Resultat = " + Post(new Facilitet() { Facilitetnr = 1, Name = "Lagkage" }));

                Console.WriteLine("Opretter et nyt Facilitet object, id findes ikke");
                Console.WriteLine("Resultat = " + Post(new Facilitet() { Facilitetnr = 2, Name = "Bold Tennis" }));

                Console.WriteLine("Opdaterer nr 2");
                Console.WriteLine("Resultat = " + Put(2, new Facilitet() { Facilitetnr = 2, Name = "Bord Tennis" }));
            }


            private List<Facilitet> GetAll()
            {
                List<Facilitet> faciliteters = new List<Facilitet>();

                using (HttpClient client = new HttpClient())
                {
                    Task<string> resTask = client.GetStringAsync(URI);
                    String jsonStr = resTask.Result;

                    faciliteters = JsonConvert.DeserializeObject<List<Facilitet>>(jsonStr);
                }


                return faciliteters;
            }



            private Facilitet GetOne(int id)
            {
                Facilitet faciliteterss = new Facilitet();

                using (HttpClient client = new HttpClient())
                {
                    Task<string> resTask = client.GetStringAsync(URI + "/" + id);
                    String jsonStr = resTask.Result;

                    faciliteterss = JsonConvert.DeserializeObject<Facilitet>(jsonStr);
                }


                return faciliteterss;
            }

            private bool Delete(int id)
            {
                bool ok = true;

                using (HttpClient client = new HttpClient())
                {
                    Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(URI + "/" + id);

                    HttpResponseMessage resp = deleteAsync.Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        String jsonStr = resp.Content.ReadAsStringAsync().Result;
                        ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                    }
                    else
                    {
                        ok = false;
                    }
                }


                return ok;
            }

            private bool Post(Facilitet hotel)
            {
                bool ok = true;

                using (HttpClient client = new HttpClient())
                {
                    String jsonStr = JsonConvert.SerializeObject(hotel);
                    StringContent content = new StringContent(jsonStr, Encoding.ASCII, "application/json");

                    Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);

                    HttpResponseMessage resp = postAsync.Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        String jsonResStr = resp.Content.ReadAsStringAsync().Result;
                        ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                    }
                    else
                    {
                        ok = false;
                    }
                }


                return ok;
            }

            private bool Put(int id, Facilitet hotel)
            {
                bool ok = true;

                using (HttpClient client = new HttpClient())
                {
                    String jsonStr = JsonConvert.SerializeObject(hotel);
                    StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                    Task<HttpResponseMessage> putAsync = client.PutAsync(URI + "/" + id, content);

                    HttpResponseMessage resp = putAsync.Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        String jsonResStr = resp.Content.ReadAsStringAsync().Result;
                        ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                    }
                    else
                    {
                        ok = false;
                    }
                }


                return ok;
            }



        }
    }
