using System.Collections.Generic;

namespace Crud_mvc_dockerDB.Models
{
    interface Required<anyclass>
    {
        void create(anyclass obj);
        void update(anyclass obj);
        void delete(anyclass obj);
        bool find(anyclass obj);
        List<anyclass> findAll();
    }
}