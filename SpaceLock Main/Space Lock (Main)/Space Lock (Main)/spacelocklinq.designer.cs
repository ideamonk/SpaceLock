﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Space_Lock__Main_
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="data")]
	public partial class spacelocklinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertsm(sm instance);
    partial void Updatesm(sm instance);
    partial void Deletesm(sm instance);
    partial void Insertsetting(setting instance);
    partial void Updatesetting(setting instance);
    partial void Deletesetting(setting instance);
    #endregion
		
		public spacelocklinqDataContext() : 
				base(global::Space_Lock__Main_.Properties.Settings.Default.dataConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public spacelocklinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public spacelocklinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public spacelocklinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public spacelocklinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<sm> sms
		{
			get
			{
				return this.GetTable<sm>();
			}
		}
		
		public System.Data.Linq.Table<setting> settings
		{
			get
			{
				return this.GetTable<setting>();
			}
		}
	}
	
	[Table(Name="dbo.sms")]
	public partial class sm : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SMS_No;
		
		private string _Phone_Number;
		
		private string _Text;
		
		private System.Nullable<System.DateTime> _Time_and_Date;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSMS_NoChanging(int value);
    partial void OnSMS_NoChanged();
    partial void OnPhone_NumberChanging(string value);
    partial void OnPhone_NumberChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnTime_and_DateChanging(System.Nullable<System.DateTime> value);
    partial void OnTime_and_DateChanged();
    #endregion
		
		public sm()
		{
			OnCreated();
		}
		
		[Column(Name="[SMS No]", Storage="_SMS_No", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SMS_No
		{
			get
			{
				return this._SMS_No;
			}
			set
			{
				if ((this._SMS_No != value))
				{
					this.OnSMS_NoChanging(value);
					this.SendPropertyChanging();
					this._SMS_No = value;
					this.SendPropertyChanged("SMS_No");
					this.OnSMS_NoChanged();
				}
			}
		}
		
		[Column(Name="[Phone Number]", Storage="_Phone_Number", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Phone_Number
		{
			get
			{
				return this._Phone_Number;
			}
			set
			{
				if ((this._Phone_Number != value))
				{
					this.OnPhone_NumberChanging(value);
					this.SendPropertyChanging();
					this._Phone_Number = value;
					this.SendPropertyChanged("Phone_Number");
					this.OnPhone_NumberChanged();
				}
			}
		}
		
		[Column(Storage="_Text", DbType="NVarChar(MAX)")]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[Column(Name="[Time and Date]", Storage="_Time_and_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> Time_and_Date
		{
			get
			{
				return this._Time_and_Date;
			}
			set
			{
				if ((this._Time_and_Date != value))
				{
					this.OnTime_and_DateChanging(value);
					this.SendPropertyChanging();
					this._Time_and_Date = value;
					this.SendPropertyChanged("Time_and_Date");
					this.OnTime_and_DateChanged();
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
	
	[Table(Name="dbo.settings")]
	public partial class setting : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _user;
		
		private string _Phone_Number;
		
		private string _Password;
		
		private int _Port_Number;
		
		private string _send;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnuserChanging(string value);
    partial void OnuserChanged();
    partial void OnPhone_NumberChanging(string value);
    partial void OnPhone_NumberChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnPort_NumberChanging(int value);
    partial void OnPort_NumberChanged();
    partial void OnsendChanging(string value);
    partial void OnsendChanged();
    #endregion
		
		public setting()
		{
			OnCreated();
		}
		
		[Column(Name="[user]", Storage="_user", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string user
		{
			get
			{
				return this._user;
			}
			set
			{
				if ((this._user != value))
				{
					this.OnuserChanging(value);
					this.SendPropertyChanging();
					this._user = value;
					this.SendPropertyChanged("user");
					this.OnuserChanged();
				}
			}
		}
		
		[Column(Name="[Phone Number]", Storage="_Phone_Number", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Phone_Number
		{
			get
			{
				return this._Phone_Number;
			}
			set
			{
				if ((this._Phone_Number != value))
				{
					this.OnPhone_NumberChanging(value);
					this.SendPropertyChanging();
					this._Phone_Number = value;
					this.SendPropertyChanged("Phone_Number");
					this.OnPhone_NumberChanged();
				}
			}
		}
		
		[Column(Storage="_Password", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[Column(Name="[Port Number]", Storage="_Port_Number", DbType="Int NOT NULL")]
		public int Port_Number
		{
			get
			{
				return this._Port_Number;
			}
			set
			{
				if ((this._Port_Number != value))
				{
					this.OnPort_NumberChanging(value);
					this.SendPropertyChanging();
					this._Port_Number = value;
					this.SendPropertyChanged("Port_Number");
					this.OnPort_NumberChanged();
				}
			}
		}
		
		[Column(Storage="_send", DbType="NChar(10)")]
		public string send
		{
			get
			{
				return this._send;
			}
			set
			{
				if ((this._send != value))
				{
					this.OnsendChanging(value);
					this.SendPropertyChanging();
					this._send = value;
					this.SendPropertyChanged("send");
					this.OnsendChanged();
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
