using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, ClientCard> m_Clients= new Dictionary<string, ClientCard>();

        public ClientCard FindByLicenceNum(string i_LicenceNum)
        {
            if (!m_Clients.ContainsKey(i_LicenceNum))
            {
                throw new ArgumentException(string.Format("Error: Licence number {0} does not exist", i_LicenceNum));
            }

            return m_Clients[i_LicenceNum];
        }

        public void ChangeVehicleState(string i_LicenceNumber, string i_NewState)
        {
            eState enumState = (eState)Enum.Parse(typeof(eState), i_NewState);

            if (!m_Clients.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException(string.Format("Error: Licence number {0} does not exist", i_LicenceNumber));
            }
            m_Clients[i_LicenceNumber].State = enumState;
        }
        public List<string> FindByState(string i_State)
        {
            eState enumState;
            try
            {
                enumState = (eState)Enum.Parse(typeof(eState), i_State);
            }
            catch
            {
                throw new FormatException(string.Format("Error: {0} is not a valid state.", i_State));
            }
            List<string> listByState = new List<string>();
            foreach(KeyValuePair<string, ClientCard> pair in m_Clients)
            {
                if(pair.Value.State == enumState)
                {
                    listByState.Add(pair.Key);
                }
            }

            return listByState;
        }

        public List<string> GetAllPlates()
        {
            List<string> plates = new List<string>();
            foreach (KeyValuePair<string, ClientCard> pair in m_Clients)
            {
                plates.Add(pair.Key);
            }

            return plates;
        }

        public void Add(ClientCard i_ToAdd)
        {
            if (m_Clients.ContainsKey(i_ToAdd.Vehicle.LicenceNumber))
            {
                throw new ArgumentException("Error: Vehicle already exsists.");
            }

            m_Clients.Add(i_ToAdd.Vehicle.LicenceNumber, i_ToAdd);
        }

        public void printVehicleData(string i_LicenceNum)
        {
            if (!m_Clients.ContainsKey(i_LicenceNum))
            {
                throw new ArgumentException(string.Format("Error: Licence number {0} does not exist", i_LicenceNum));
            }

            m_Clients[i_LicenceNum].ToString();
        }

        public void inflateWheels(string i_LicenceNum)
        {
            checkLicenceExist(i_LicenceNum);
            m_Clients[i_LicenceNum].Vehicle.FillToMax();    //add thie method to vehicle . 
        }

        private void checkLicenceExist(string i_LicenceNum)
        {
            if (!m_Clients.ContainsKey(i_LicenceNum))
            {
                throw new ArgumentException(string.Format("Error: Licence number {0} does not exist", i_LicenceNum));
            }
        }
    }
}
