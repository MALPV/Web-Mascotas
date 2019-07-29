using System;
using Negocio;
using WebAppMascotas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMascotas.Controllers
{
    public class HomeController : Controller
    {
        GestorMascota gestor = new GestorMascota();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult List()
        {
            var listaModels = new List<Mascota>();
            foreach (EMascota ma in gestor.BuscarTodo())
            {
                listaModels.Add(new Mascota
                {
                    id = ma.id,
                    nomMascota = ma.nomMascota,
                    edad = ma.edad,
                    raza = ma.raza,
                    sexo = ma.sexo

                });
            }

            return View("List", listaModels);

        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(EMascota m)
        {
            if (ModelState.IsValid)
                try
                {
                    EMascota mascota = new EMascota
                    {
                        id = m.id,
                        nomMascota = m.nomMascota,
                        raza = m.raza,
                        edad = m.edad,
                        sexo = m.sexo
                    };

                    if (gestor.Crear(mascota) == false)
                    {
                        ViewBag.Error = "ID ya registrado";
                        //return RedirectToAction("Create");
                    }
                    else
                    {
                        var listaModels = new List<Mascota>();
                        foreach (EMascota ma in gestor.BuscarTodo())
                        {
                            listaModels.Add(new Mascota
                            {
                                id = ma.id,
                                nomMascota = ma.nomMascota,
                                edad = ma.edad,
                                raza = ma.raza,
                                sexo = ma.sexo

                            });
                        }
                        return View("List", listaModels);
                    }

                    return View();

                }
                catch
                {
                    return View();
                }
            else
                return View(m);
        }

        // GET: Home/Buscar/5
        public ActionResult Buscar()
        {
            return View(new EMascota());
        }

        // POST: Home/Buscar/5
        [HttpPost]
        public ActionResult Buscar(EMascota eMascota)
        {
            EMascota mascota = gestor.Buscar(eMascota.id);

            return View(mascota);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            EMascota mascota = gestor.Buscar(id);
            return View(mascota);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(EMascota eMascota)
        {
            if (ModelState.IsValid)
                try
                {
                    bool a = gestor.Actualizar(eMascota);

                    if (a)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        return View(eMascota);
                    }
                }
                catch
                {
                    return View();
                }
            else
                return View(eMascota);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            EMascota mascota = gestor.Buscar(id);
            return View(mascota);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(EMascota eMascota)
        {
            try
            {
                bool a = gestor.Eliminar(eMascota);

                if (a)
                {
                    return RedirectToAction("List");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
