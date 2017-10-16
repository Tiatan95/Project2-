using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTS_Project
{

    public class TerminalController
    {
        private ITerminalDevice terminalDevice;
        private List<Tenant> tenants = new List<Tenant>();
        private Tenant currentTenant;

        public TerminalController(ITerminalDevice terminalDevice)
        {
            this.terminalDevice = terminalDevice;
        }

        public void Activate()
        {
            //verify password and if verified, show MainMenuDialog
            // if a user presses "Cancel", do nothing and just return
            string password = null;
            if (!terminalDevice.GetPassword(ref password)) return;
            // you need to verify the password

            terminalDevice.ShowMainMenuDialog(this);
        }

        // handlers for MainMenuDialog
        public void AddTenant_Handler()
        {
            // Add a tenant
            // Get the name and access code of the tenant to be added
            string firstName = null;
            string lastName = null;
            string accessCode = null;
            if (!terminalDevice.GetTenantInfo(ref firstName, ref lastName, ref accessCode)) return;

            Tenant tenant = new Tenant(firstName, lastName, accessCode);
            tenants.Add(tenant);

        }

        public void DeleteTenant_Handler()
        {
            // Delete a tenant
            // Get the first name and the last name of the tenant to be deleted
            string firstName = null;
            string lastName = null;
            if (!terminalDevice.GetTenantName(ref firstName, ref lastName)) return;

            foreach(Tenant i in tenants)
            {
                if(i.FirstName.Equals(firstName))
                {
                    if(i.LastName.Equals(lastName))
                    {
                        tenants.Remove(i);
                    }
                }
            }

        }

        public void WorkOnTenant_Handler()
        {
            // Work on a specific tenant
            // Input the first name and the last name of the tenant to work on
            string firstName = null;
            string lastName = null;
            if (!terminalDevice.GetTenantName(ref firstName, ref lastName)) return;
            
            foreach(Tenant t in tenants)
            {
                if(t.FirstName.Equals(firstName))
                {
                    if(t.LastName.Equals(lastName))
                    {
                        currentTenant = t;
                    }
                }
            }
            terminalDevice.ShowTenantMenuDialog(this);
        }

        public void DisplayTenantList_Handler()
        {
            // call "void DisplayList(object[] list)" to list Tenants
            terminalDevice.DisplayList(tenants.ToArray());
           
        }

        public void Save_Handler()
        {

        }

        public void Restore_Handler()
        {

        }

        public void ChangePassword_Handler()
        {
            string password = null;
            if (!terminalDevice.GetPassword(ref password)) return;

        }

        // ==== Handlers for TenantMenuDialog
        public void BarAreaCode_Handler()
        {
            // Bar an area code
            // Input the area code to bar
            string areaCode = null;
            if (!terminalDevice.GetAreaCode(ref areaCode)) return;
            BarArea area = new BarArea(areaCode);
            currentTenant.barredNumbers.Add(area);
        }

        public void BarTelephoneNumber_Handler()
        {
            // Bar a telephone number
            // Input the telephone number to bar
            string areaCode = null;
            string exchange = null;
            string number = null;
            if (!terminalDevice.GetTelephoneNumber(ref areaCode, ref exchange, ref number)) return;
            Calls newNumber = new Calls(areaCode, exchange, number, DateTime.Now, DateTime.Now);
            BarNumber barNumber = new BarNumber(newNumber);
            currentTenant.barredNumbers.Add(barNumber);
        }

        public void UnBarAreaCode_Handler()
        {
            // Unbar an area code
            // Input the area code to unbar
            string areaCode = null;
            if (!terminalDevice.GetAreaCode(ref areaCode)) return;

            foreach(BarArea ba in currentTenant.barredNumbers)
            {
                if(areaCode.Equals(ba.number))
                {
                    currentTenant.barredNumbers.Remove(ba);
                }
            }

        }

        public void UnBarTelephoneNumber_Handler()
        {
            // Unbar a telephone number
            // Input the telephone number to unbar 
            string areaCode = null;
            string exchange = null;
            string number = null;
            if (!terminalDevice.GetTelephoneNumber(ref areaCode, ref exchange, ref number)) return;
            Calls newCall = new Calls(areaCode, exchange, number, DateTime.Now, DateTime.Now);

            foreach (BarNumber ba in currentTenant.barredNumbers)
            {
                if (newCall.ToString().Equals(ba.number))
                {
                    currentTenant.barredNumbers.Remove(ba);
                }
            }
        }

        public void DisplayCallList_Handler()
        {
            // call  "void DisplayList(object[] list)" to list Calls
            terminalDevice.DisplayList(currentTenant.phoneCalls.ToArray());        
        }

        public void DisplayBarList_Handler()
        {
            // call "void DisplayList(object[] list)" to list Bar Numbers
            terminalDevice.DisplayList(currentTenant.barredNumbers.ToArray());
        }

        public void ClearCalls_Handler()
        {
            currentTenant.phoneCalls = new List<Calls>();
        }
    }
}
