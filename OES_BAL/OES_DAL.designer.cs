﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OES_BAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OES_DB")]
	public partial class OES_DALDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertdb_user(db_user instance);
    partial void Updatedb_user(db_user instance);
    partial void Deletedb_user(db_user instance);
    partial void Insertdb_program(db_program instance);
    partial void Updatedb_program(db_program instance);
    partial void Deletedb_program(db_program instance);
    #endregion
		
		public OES_DALDataContext() : 
				base(global::OES_BAL.Properties.Settings.Default.OES_DBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public OES_DALDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OES_DALDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OES_DALDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OES_DALDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		internal System.Data.Linq.Table<db_user> db_users
		{
			get
			{
				return this.GetTable<db_user>();
			}
		}
		
		internal System.Data.Linq.Table<db_program> db_programs
		{
			get
			{
				return this.GetTable<db_program>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[user]")]
	internal partial class db_user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private string _first_name;
		
		private string _last_name;
		
		private string _user_email;
		
		private string _user_password;
		
		private string _user_name;
		
		private string _user_gender;
		
		private string _user_address;
		
		private string _user_contact;
		
		private string _user_image;
		
		private System.Nullable<System.DateTime> _created_when;
		
		private string _created_by;
		
		private System.Nullable<System.DateTime> _edited_when;
		
		private string _edited_by;
		
		private bool _is_firstLogin;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onfirst_nameChanging(string value);
    partial void Onfirst_nameChanged();
    partial void Onlast_nameChanging(string value);
    partial void Onlast_nameChanged();
    partial void Onuser_emailChanging(string value);
    partial void Onuser_emailChanged();
    partial void Onuser_passwordChanging(string value);
    partial void Onuser_passwordChanged();
    partial void Onuser_nameChanging(string value);
    partial void Onuser_nameChanged();
    partial void Onuser_genderChanging(string value);
    partial void Onuser_genderChanged();
    partial void Onuser_addressChanging(string value);
    partial void Onuser_addressChanged();
    partial void Onuser_contactChanging(string value);
    partial void Onuser_contactChanged();
    partial void Onuser_imageChanging(string value);
    partial void Onuser_imageChanged();
    partial void Oncreated_whenChanging(System.Nullable<System.DateTime> value);
    partial void Oncreated_whenChanged();
    partial void Oncreated_byChanging(string value);
    partial void Oncreated_byChanged();
    partial void Onedited_whenChanging(System.Nullable<System.DateTime> value);
    partial void Onedited_whenChanged();
    partial void Onedited_byChanging(string value);
    partial void Onedited_byChanged();
    partial void Onis_firstLoginChanging(bool value);
    partial void Onis_firstLoginChanged();
    #endregion
		
		public db_user()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_first_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string first_name
		{
			get
			{
				return this._first_name;
			}
			set
			{
				if ((this._first_name != value))
				{
					this.Onfirst_nameChanging(value);
					this.SendPropertyChanging();
					this._first_name = value;
					this.SendPropertyChanged("first_name");
					this.Onfirst_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_last_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string last_name
		{
			get
			{
				return this._last_name;
			}
			set
			{
				if ((this._last_name != value))
				{
					this.Onlast_nameChanging(value);
					this.SendPropertyChanging();
					this._last_name = value;
					this.SendPropertyChanged("last_name");
					this.Onlast_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string user_email
		{
			get
			{
				return this._user_email;
			}
			set
			{
				if ((this._user_email != value))
				{
					this.Onuser_emailChanging(value);
					this.SendPropertyChanging();
					this._user_email = value;
					this.SendPropertyChanged("user_email");
					this.Onuser_emailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_password", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string user_password
		{
			get
			{
				return this._user_password;
			}
			set
			{
				if ((this._user_password != value))
				{
					this.Onuser_passwordChanging(value);
					this.SendPropertyChanging();
					this._user_password = value;
					this.SendPropertyChanged("user_password");
					this.Onuser_passwordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string user_name
		{
			get
			{
				return this._user_name;
			}
			set
			{
				if ((this._user_name != value))
				{
					this.Onuser_nameChanging(value);
					this.SendPropertyChanging();
					this._user_name = value;
					this.SendPropertyChanged("user_name");
					this.Onuser_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_gender", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string user_gender
		{
			get
			{
				return this._user_gender;
			}
			set
			{
				if ((this._user_gender != value))
				{
					this.Onuser_genderChanging(value);
					this.SendPropertyChanging();
					this._user_gender = value;
					this.SendPropertyChanged("user_gender");
					this.Onuser_genderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_address", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string user_address
		{
			get
			{
				return this._user_address;
			}
			set
			{
				if ((this._user_address != value))
				{
					this.Onuser_addressChanging(value);
					this.SendPropertyChanging();
					this._user_address = value;
					this.SendPropertyChanged("user_address");
					this.Onuser_addressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_contact", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string user_contact
		{
			get
			{
				return this._user_contact;
			}
			set
			{
				if ((this._user_contact != value))
				{
					this.Onuser_contactChanging(value);
					this.SendPropertyChanging();
					this._user_contact = value;
					this.SendPropertyChanged("user_contact");
					this.Onuser_contactChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_image", DbType="VarChar(50)")]
		public string user_image
		{
			get
			{
				return this._user_image;
			}
			set
			{
				if ((this._user_image != value))
				{
					this.Onuser_imageChanging(value);
					this.SendPropertyChanging();
					this._user_image = value;
					this.SendPropertyChanged("user_image");
					this.Onuser_imageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_when", DbType="DateTime")]
		public System.Nullable<System.DateTime> created_when
		{
			get
			{
				return this._created_when;
			}
			set
			{
				if ((this._created_when != value))
				{
					this.Oncreated_whenChanging(value);
					this.SendPropertyChanging();
					this._created_when = value;
					this.SendPropertyChanged("created_when");
					this.Oncreated_whenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_by", DbType="VarChar(50)")]
		public string created_by
		{
			get
			{
				return this._created_by;
			}
			set
			{
				if ((this._created_by != value))
				{
					this.Oncreated_byChanging(value);
					this.SendPropertyChanging();
					this._created_by = value;
					this.SendPropertyChanged("created_by");
					this.Oncreated_byChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_edited_when", DbType="DateTime")]
		public System.Nullable<System.DateTime> edited_when
		{
			get
			{
				return this._edited_when;
			}
			set
			{
				if ((this._edited_when != value))
				{
					this.Onedited_whenChanging(value);
					this.SendPropertyChanging();
					this._edited_when = value;
					this.SendPropertyChanged("edited_when");
					this.Onedited_whenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_edited_by", DbType="VarChar(50)")]
		public string edited_by
		{
			get
			{
				return this._edited_by;
			}
			set
			{
				if ((this._edited_by != value))
				{
					this.Onedited_byChanging(value);
					this.SendPropertyChanging();
					this._edited_by = value;
					this.SendPropertyChanged("edited_by");
					this.Onedited_byChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_firstLogin", DbType="Bit NOT NULL")]
		public bool is_firstLogin
		{
			get
			{
				return this._is_firstLogin;
			}
			set
			{
				if ((this._is_firstLogin != value))
				{
					this.Onis_firstLoginChanging(value);
					this.SendPropertyChanging();
					this._is_firstLogin = value;
					this.SendPropertyChanged("is_firstLogin");
					this.Onis_firstLoginChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.program")]
	internal partial class db_program : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _program_id;
		
		private string _program_code;
		
		private string _program_name;
		
		private string _program_details;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onprogram_idChanging(int value);
    partial void Onprogram_idChanged();
    partial void Onprogram_codeChanging(string value);
    partial void Onprogram_codeChanged();
    partial void Onprogram_nameChanging(string value);
    partial void Onprogram_nameChanged();
    partial void Onprogram_detailsChanging(string value);
    partial void Onprogram_detailsChanged();
    #endregion
		
		public db_program()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_program_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int program_id
		{
			get
			{
				return this._program_id;
			}
			set
			{
				if ((this._program_id != value))
				{
					this.Onprogram_idChanging(value);
					this.SendPropertyChanging();
					this._program_id = value;
					this.SendPropertyChanged("program_id");
					this.Onprogram_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_program_code", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string program_code
		{
			get
			{
				return this._program_code;
			}
			set
			{
				if ((this._program_code != value))
				{
					this.Onprogram_codeChanging(value);
					this.SendPropertyChanging();
					this._program_code = value;
					this.SendPropertyChanged("program_code");
					this.Onprogram_codeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_program_name", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string program_name
		{
			get
			{
				return this._program_name;
			}
			set
			{
				if ((this._program_name != value))
				{
					this.Onprogram_nameChanging(value);
					this.SendPropertyChanging();
					this._program_name = value;
					this.SendPropertyChanged("program_name");
					this.Onprogram_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_program_details", DbType="VarChar(MAX)")]
		public string program_details
		{
			get
			{
				return this._program_details;
			}
			set
			{
				if ((this._program_details != value))
				{
					this.Onprogram_detailsChanging(value);
					this.SendPropertyChanging();
					this._program_details = value;
					this.SendPropertyChanged("program_details");
					this.Onprogram_detailsChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
