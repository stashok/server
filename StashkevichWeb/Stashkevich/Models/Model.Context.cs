﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stashkevich.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class stashkevichEntities : DbContext
    {
        public stashkevichEntities()
            : base("name=stashkevichEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int CreateMessage(Nullable<int> sender, Nullable<int> reciever, string text, Nullable<System.DateTime> date)
        {
            var senderParameter = sender.HasValue ?
                new ObjectParameter("Sender", sender) :
                new ObjectParameter("Sender", typeof(int));
    
            var recieverParameter = reciever.HasValue ?
                new ObjectParameter("Reciever", reciever) :
                new ObjectParameter("Reciever", typeof(int));
    
            var textParameter = text != null ?
                new ObjectParameter("Text", text) :
                new ObjectParameter("Text", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateMessage", senderParameter, recieverParameter, textParameter, dateParameter);
        }
    
        public virtual int CreateUser(string userName, string password, Nullable<int> isAdmin)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var isAdminParameter = isAdmin.HasValue ?
                new ObjectParameter("IsAdmin", isAdmin) :
                new ObjectParameter("IsAdmin", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUser", userNameParameter, passwordParameter, isAdminParameter);
        }
    
        public virtual ObjectResult<GetUsers_Result> GetUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUsers_Result>("GetUsers");
        }
    }
}
