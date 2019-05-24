﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ClientCard
    {
        private static readonly List<string> rs_VehicleStatusSet;
        private string m_OwnerName;
        private string m_OwnerCellPhone;
        private Vehicle m_Vehicle;
        private eState m_State = eState.onWork;

        static ClientCard()
        {
            rs_VehicleStatusSet = new List<string> { "on work", "finished", "payed"};
        }
        public ClientCard(string i_Name, string i_Phone, Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_Name;
            m_OwnerCellPhone = i_Phone;
        }
        // properties:

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }
        
        public static string[] VehicleStatusSet
        {
            get { return rs_VehicleStatusSet; }
        }
        public string OwnerCellPhone
        {
            get { return m_OwnerCellPhone; }
            set { m_OwnerCellPhone = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        public eState State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        // methods:

        public void FillEnergy(string i_Amount, string i_Type)
        {
            m_Vehicle.FillEnergy(i_Amount, i_Type);
        }

        public override string ToString()
        {
            return string.Format(@"Owner: {0}
State: {1}
Phone Number: {2}
{3}", m_OwnerName, m_State, m_OwnerCellPhone, m_Vehicle.ToString());
        }
    }
}
