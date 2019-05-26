using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, ClientCard> m_Clients = new Dictionary<string, ClientCard>();

        public ClientCard FindByLicenceNum(string i_LicenceNum)
        {
            if (m_Clients.ContainsKey(i_LicenceNum))
            {
                return m_Clients[i_LicenceNum];
            }

            throw new ArgumentException(string.Format("Error: Licence number \"{0}\" does not exist in the garage.", i_LicenceNum));
        }

        public void ChangeVehicleState(string i_LicenceNumber, string i_NewState)
        {
            if (!m_Clients.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException(string.Format("Error: Licence number {0} does not exist", i_LicenceNumber));
            }

            m_Clients[i_LicenceNumber].State = statusToState(i_NewState);
        }

        private ClientCard.eState statusToState(string i_Status)
        {
            int index = 0;
            foreach (string status in ClientCard.VehicleStatusSet)
            {
                if (status.Equals(i_Status.ToLower()))
                {
                    return (ClientCard.eState)index;
                }

                index++;
            }

            throw new FormatException(string.Format(
                @"Error: {0} is not a valid status of vehicle.
status must be on of the following: on work, finished, payed",
                i_Status));
        }

        public List<string> FindByState(string i_State)
        {
            ClientCard.eState enumState = statusToState(i_State);
         
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
                i_ToAdd.State = statusToState(ClientCard.VehicleStatusSet[(int)ClientCard.eState.onWork]);
                throw new ArgumentException("Error: Vehicle already exsists. status modified to \"on work\"");
            }

            m_Clients.Add(i_ToAdd.Vehicle.LicenceNumber, i_ToAdd);
        }

        public string GetVehicleData(string i_LicenceNum)
        {
            if (!m_Clients.ContainsKey(i_LicenceNum))
            {
                throw new ArgumentException(string.Format("Error: Licence number {0} does not exist", i_LicenceNum));
            }

            return m_Clients[i_LicenceNum].ToString();
        }

        public void inflateWheels(string i_LicenceNum)
        {
            checkLicenceExist(i_LicenceNum);
            m_Clients[i_LicenceNum].Vehicle.FillToMax();
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
