﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ClientCard
    {
        private string m_OwnerName;
        private string m_OwnerCellPhone;
        private Vehicle m_Vehicle;
        private eState m_State = eState.onWork;

        // properties:

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
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

        public void InflateWheels(float i_Amount)
        {
            m_Vehicle.FillUpAirPressure();
        }

        //public void FillEnergy(float i_Amount, int i_Type)
        //{
        //    m_Vehicle.FillUpEnergy(i_Amount, i_Type);
        //}

        public override string ToString()
        {
            return string.Format(@"Owner: {0}
State: {1}
Phone Number: {2}
{3}", m_OwnerName, m_State, m_OwnerCellPhone, m_Vehicle.ToString());
        }
    }
}
