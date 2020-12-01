using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.Base
{
    //all pageobject classes should inherit BasePage
    public class BasePage
    {
        //converts different page classes into GenericType type to be cast into other pages
        public GenericType As<GenericType>() where GenericType : BasePage
        {
            return (GenericType)this;
        }
    }
}
