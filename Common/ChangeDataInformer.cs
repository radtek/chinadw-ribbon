using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace BSB.Common
{
	/// <summary>
	/// Summary description for CacheManuals.
	/// </summary>
	public class ChangeDataInformer: System.ComponentModel.Component
	{
		private ODPUtils.ODPOracleEvent odpOracleEvent;
		private System.ComponentModel.IContainer components;

		public ChangeDataInformer(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
		
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			odpOracleEvent.OwnerForm = dmControler.frmMain;
			odpOracleEvent.Connection = dmControler.frmMain.oracleConnection;
		}

		public ChangeDataInformer()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			odpOracleEvent.OwnerForm = dmControler.frmMain;
			odpOracleEvent.Connection = dmControler.frmMain.oracleConnection;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.odpOracleEvent = new ODPUtils.ODPOracleEvent(this.components);
			// 
			// odpOracleEvent
			// 
			this.odpOracleEvent.Connection = null;
			this.odpOracleEvent.ObjectNames = "CHANGE_DATA";
			this.odpOracleEvent.ObjectType = ODPUtils.TEventObjectType.otAlert;
			this.odpOracleEvent.OwnerForm = null;
			this.odpOracleEvent.TimeOut = 0;
			this.odpOracleEvent.OnEvent += new ODPUtils.ODPOracleEvent.OnEventHandler(this.odpOracleEvent_OnEvent);

		}
		#endregion
	
		public delegate void ChangeDataDelegate(System.Collections.ArrayList Info);
		public event ChangeDataDelegate ChangeData;

		private void odpOracleEvent_OnEvent(object Sender, string ObjectName, System.Collections.ArrayList Info)
		{
			if (ObjectName == "CHANGE_DATA") 
				OnChangeData(Info);
		}

		private void OnChangeData(System.Collections.ArrayList Info)
		{
			ChangeData(Info);
		}

	}
}
