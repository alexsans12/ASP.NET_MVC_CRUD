using System.Collections.Generic;
using Crud_mvc_dockerDB.Models.Class;

namespace Crud_mvc_dockerDB.Models
{
    interface Required<anyclass>
    {
        void create(anyclass obj);
        void update(anyclass obj);
        void delete(anyclass obj);
        User find(anyclass obj);
        List<anyclass> findAll();
    }
}