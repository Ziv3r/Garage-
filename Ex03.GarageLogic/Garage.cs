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

        public void ChangeVehicleState(string i_numOfVehicle, eState i_NewState)
        {
            if(!m_Clients.ContainsKey(i_numOfVehicle))
            {
                throw new ArgumentException(string.Format("Error: Licence number {0} does not exist", i_numOfVehicle));
            }
            m_Clients[i_numOfVehicle].State = i_NewState;
        }
        public List<string> FindByState(eState i_State)
        {
            if(!Enum.IsDefined(typeof(eState),i_State))
            {
                throw new ArgumentException(string.Format("Error: {0} is not a valid state.", i_State));
            }

            List<string> filteredClients = new List<string>();
            foreach(KeyValuePair<string, ClientCard> pair in m_Clients)
            {
                if(pair.Value.State == i_State)
                {
                    filteredClients.Add(pair.Key);
                }
            }

            return filteredClients;
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

        //public void Add(ClientCard i_ToAdd)
        //{
        //    if (m_Clients.ContainsKey(i_ToAdd.Vehicle.LicenceNumber))
        //    {
        //        throw new InvalidOperationException("Error: Vehicle already exsists.");
        //    }

        //    m_Clients.Add(i_ToAdd.Vehicle.LicenceNumber, i_ToAdd);
        //}
    }
}
