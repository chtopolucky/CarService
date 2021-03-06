//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class АвтоСервисEntities : DbContext
    {
        public АвтоСервисEntities()
            : base("name=АвтоСервисEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ВидыРаботы> ВидыРаботы { get; set; }
        public virtual DbSet<Заказы> Заказы { get; set; }
        public virtual DbSet<Исполнители> Исполнители { get; set; }
        public virtual DbSet<Клиенты> Клиенты { get; set; }
        static АвтоСервисEntities context;
        public static АвтоСервисEntities GetContext()
        {
            if (context == null) context = new АвтоСервисEntities();
            return context;
        }
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<ГлавноеОкно_Result> ГлавноеОкно()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ГлавноеОкно_Result>("ГлавноеОкно");
        }
    
        public virtual int ДобавлениеКлиента(Nullable<int> код, string фИО, Nullable<System.DateTime> датаРождения, string адрес, string телефон)
        {
            var кодParameter = код.HasValue ?
                new ObjectParameter("Код", код) :
                new ObjectParameter("Код", typeof(int));
    
            var фИОParameter = фИО != null ?
                new ObjectParameter("ФИО", фИО) :
                new ObjectParameter("ФИО", typeof(string));
    
            var датаРожденияParameter = датаРождения.HasValue ?
                new ObjectParameter("ДатаРождения", датаРождения) :
                new ObjectParameter("ДатаРождения", typeof(System.DateTime));
    
            var адресParameter = адрес != null ?
                new ObjectParameter("Адрес", адрес) :
                new ObjectParameter("Адрес", typeof(string));
    
            var телефонParameter = телефон != null ?
                new ObjectParameter("Телефон", телефон) :
                new ObjectParameter("Телефон", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ДобавлениеКлиента", кодParameter, фИОParameter, датаРожденияParameter, адресParameter, телефонParameter);
        }
    
        public virtual ObjectResult<КоличествоЗаказовАвтомобилей_Result> КоличествоЗаказовАвтомобилей()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<КоличествоЗаказовАвтомобилей_Result>("КоличествоЗаказовАвтомобилей");
        }
    
        public virtual ObjectResult<СтоимостьЗаказовКлиентов_Result> СтоимостьЗаказовКлиентов()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<СтоимостьЗаказовКлиентов_Result>("СтоимостьЗаказовКлиентов");
        }
    
        public virtual ObjectResult<СтоимостьРаботИсполнителей_Result> СтоимостьРаботИсполнителей()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<СтоимостьРаботИсполнителей_Result>("СтоимостьРаботИсполнителей");
        }
    
        public virtual ObjectResult<СправочникВидовРабот_Result> СправочникВидовРабот()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<СправочникВидовРабот_Result>("СправочникВидовРабот");
        }
    
        public virtual int ДобавлениеИсполнителя(Nullable<int> код, string фИО)
        {
            var кодParameter = код.HasValue ?
                new ObjectParameter("Код", код) :
                new ObjectParameter("Код", typeof(int));
    
            var фИОParameter = фИО != null ?
                new ObjectParameter("ФИО", фИО) :
                new ObjectParameter("ФИО", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ДобавлениеИсполнителя", кодParameter, фИОParameter);
        }
    
        public virtual ObjectResult<ЗаказыПервыйКвартал_Result> ЗаказыПервыйКвартал()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ЗаказыПервыйКвартал_Result>("ЗаказыПервыйКвартал");
        }
    
        public virtual ObjectResult<КоличествоЗаказовДень_Result> КоличествоЗаказовДень(Nullable<System.DateTime> дата)
        {
            var датаParameter = дата.HasValue ?
                new ObjectParameter("Дата", дата) :
                new ObjectParameter("Дата", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<КоличествоЗаказовДень_Result>("КоличествоЗаказовДень", датаParameter);
        }
    }
}
