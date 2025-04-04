﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Highlanders.Feature.GenerateTemplates.Repository;


namespace Highlanders.Feature.GenerateTemplates.Controllers
{
    public class CreateTemplatesController: Controller
    {
        private readonly ICreateTemplatesRepository _ICreateTemplatesRepository;

        public CreateTemplatesController(ICreateTemplatesRepository iCreateTemplatesRepository)
        {
            _ICreateTemplatesRepository = iCreateTemplatesRepository;
        }
        public ActionResult CreateTemplates()
        {            
            _ICreateTemplatesRepository.CreateYmlFiles("Create templates relating to create article items");
            return View();
        }
    }
}