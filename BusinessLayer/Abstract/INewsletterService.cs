﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsletterService
    {
        //yeni haber bülteni eklemek için
        void AddNewsletter(Newsletter newsletter);

    }
}