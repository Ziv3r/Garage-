using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private Dictionary<string, ClientCard> m_Clients= new Dictionary<string, ClientCard>();

        public ClientCard FindByLicenceNum(string i_LicenceNum)
        {
            return m_Clients[i_LicenceNum];
        }

        public List<string> FindByState(int i_State)
        {
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

        public List<string> getAllPlates()
        {
            List<string> plates = new List<string>();
            foreach (KeyValuePair<string, ClientCard> pair in m_Clients)
            {
                    plates.Add(pair.Key);
                
            }

            return plates;
        }

        public void Add(ClientCard i_ToAdd, string i_ClientName, string i_ClientPhone)
        {
            if (m_Clients.ContainsKey(i_ToAdd.Vehicle.LicenceNumber))
            {
                throw new Exception("Error: Vehicle already exsists.");
            }

            m_Clients.Add(i_ToAdd.LicenceNumber,i_ToAdd)
        }
    }
}
