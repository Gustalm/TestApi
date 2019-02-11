using System;
using System.Collections.Generic;
using System.Text;

namespace Dotz.Fidelity.Infra.Data.Statements
{
    public class CustomerStatements
    {
        public const string InsertCustomer = @"
	                                        INSERT INTO fidelity.customers(
	                                        NAME, 
	                                        EMAIL, 
	                                        CPF, 
	                                        HASH, 
	                                        SALT, 
	                                        BIRTHDATE
	                                        )
	                                        VALUES(
	                                        :NAME,
	                                        :EMAIL,
	                                        :CPF,
	                                        :PASSWORDHASH,
	                                        :PASSWORDSALT, 
	                                        :BIRTHDATE); select LAST_INSERT_ID();";

        public const string GetByEmail = @"SELECT * FROM fidelity.customers where email =  :email";

        public const string GetById = @"SELECT * FROM fidelity.customers where ID = :id";

    }
}
