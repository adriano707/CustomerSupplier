using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSupplier.Domain.Test
{
    public class CustomerSupplierTest
    {
        [Fact]
        public void Create_new_customer_supplier()
        {
            string customerName = "novo customer";

            Entities.CustomerSupplier customerSupplier = new Entities.CustomerSupplier(customerName);
            Assert.Equal(customerSupplier.Name, customerName);
        }

        [Fact]
        public void Add_contant_in_customer_supplier()
        {
            string customerName = "novo customer";
            string customerEmail = "teste@teste.com.br";
            string phone = "5555555";

            Entities.CustomerSupplier customerSupplier = new Entities.CustomerSupplier(customerName);
            customerSupplier.AddContact(customerEmail,phone);

            Assert.True(customerSupplier.ContactList.Any());
        }
    }
}
