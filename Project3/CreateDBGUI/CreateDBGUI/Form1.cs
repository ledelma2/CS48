//
//  Windows  Form  App  to  allow  bike  rentals  via  the  BikeHike  database.
//
//  Liam Edelman
//  U.  of  Illinois,  Chicago
//  CS480,  Summer  2018
//  Project  #2
//



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDBGUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private bool bikeExists(int bikeID)
        {
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);
            string checkID = string.Format(@"
            SELECT BID
            FROM Bike
            WHERE BID = {0};",
            bikeID);

            var exists = data.ExecuteScalarQuery(checkID);

            if (exists == null)
            {
                string msg = string.Format("Bike ID not found: '{0}'",
                  bikeID);
                MessageBox.Show(msg);
                return false;
            }

            return true;
        }

        private bool bikeAvailable(int bikeID)
        {
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);
            string checkAva = string.Format(@"
            SELECT RentedOut
            FROM Bike
            WHERE BID = {0};",
            bikeID);

            var available = data.ExecuteScalarQuery(checkAva);

            if (available.Equals(true))
            {
                string msg = string.Format("Bike ID is not available: '{0}'",
                  bikeID);
                MessageBox.Show(msg);
                return false;
            }

            return true;
        }

        private bool fileExists(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                string msg = string.Format("Input file not found: '{0}'",
                  filename);

                MessageBox.Show(msg);
                return false;
            }

            // exists!
            return true;
        }

        private void CustDisplay_Click(object sender, EventArgs e)
        {
            if (!fileExists(this.Filename.Text))
                return;
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);

            PrimeData.Items.Clear();
            SecData.Items.Clear();

            string dispCusts = string.Format(@"
            SELECT LastName, FirstName
            FROM Customer
            ORDER BY LastName ASC, FirstName ASC;");

            DataSet ds = new DataSet();
            ds = data.ExecuteNonScalarQuery(dispCusts);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PrimeData.Items.Add(row["LastName"].ToString() + "," + row["FirstName"].ToString());
            }
        }

        private void BikeDisp_Click(object sender, EventArgs e)
        {
            if (!fileExists(this.Filename.Text))
                return;
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);

            PrimeData.Items.Clear();
            SecData.Items.Clear();

            string dispBikes = string.Format(@"
            SELECT BID
            FROM Bike
            ORDER BY BID ASC;");

            DataSet ds = new DataSet();
            ds = data.ExecuteNonScalarQuery(dispBikes);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PrimeData.Items.Add("BID: " + row["BID"].ToString());
            }
        }

        private void DispRent_Click(object sender, EventArgs e)
        {
            if (!fileExists(this.Filename.Text))
                return;
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);

            RentalBox.Items.Clear();

            string dispRents = string.Format(@"
            SELECT Bike.BID, Bike_Type._Description, Bike.BTID, Bike.YearDeployed
            FROM Bike WITH (INDEX(BTID_Index))
            INNER JOIN Bike_Type ON Bike_Type.BTID = Bike.BTID
            WHERE RentedOut = 0
            ORDER BY BTID ASC, YearDeployed DESC, BID ASC;");

            DataSet ds = new DataSet();
            ds = data.ExecuteNonScalarQuery(dispRents);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RentalBox.Items.Add(row["BID"].ToString() + ", " + row["_Description"].ToString() + ", " + row["YearDeployed"].ToString());
            }
        }

        private void ReturnRental_Click(object sender, EventArgs e)
        {
            if (!fileExists(this.Filename.Text))
                return;
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);


            string primeData = this.PrimeData.Text;

            if (primeData.Contains(" ") || primeData == "")
                return;

            string[] name = primeData.Split(',');
            string custIDSql = string.Format(@"
            SELECT CID
            FROM Customer
            WHERE LastName = '{0}' AND FirstName = '{1}';",
            name[0], name[1]);

            var custIDOBJ = data.ExecuteScalarQuery(custIDSql);
            int custID = Int32.Parse(custIDOBJ.ToString());

            string custSql = string.Format(@"
            SELECT RentingOut
            FROM Customer
            WHERE CID = {0};",
            custID);

            var d = data.ExecuteScalarQuery(custSql);

            if (d.Equals(false))
            {
                MessageBox.Show("Customer is not currently renting out a bike...");
                return;
            }

            string getBID = string.Format(@"
            SELECT RID, BID
            FROM Rentals WITH (INDEX(CID_Index))
            WHERE CID = {0} AND Returned IS NULL;",
            custID);

            DataSet ds = new DataSet();
            ds = data.ExecuteNonScalarQuery(getBID);

            string rentalUpdate = string.Format(@"
            UPDATE Rentals
                SET Returned = GetDate()
                WHERE CID = {0};",
            custID);

            var db = data.ExecuteActionQuery(rentalUpdate, null, false);

            string custUpdate = string.Format(@"
            UPDATE Customer
                SET RentingOut = 0
                WHERE CID = {0};",
            custID);

            data.ExecuteActionQuery(custUpdate, db, false);
            
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                string bikeUpdate = string.Format(@"
                UPDATE Bike
                    SET RentedOut = 0
                    WHERE BID = {0};",
                row["BID"]);

                data.ExecuteActionQuery(bikeUpdate, db, true);
            }

            double total = 0.0;
            DataSet money = new DataSet();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string bikeUpdate = string.Format(@"
                SELECT Bike_Type.Price, Rentals._Started, Rentals.Returned
                FROM Rentals WITH (INDEX(BID_Index))
                INNER JOIN Bike ON Bike.BID = Rentals.BID
                INNER JOIN Bike_Type ON Bike.BTID = Bike_Type.BTID
                WHERE RID = {0};",
                row["RID"]);

                money = data.ExecuteNonScalarQuery(bikeUpdate);
                double price = Convert.ToDouble(money.Tables[0].Rows[0]["Price"]);
                TimeSpan datetime = Convert.ToDateTime(money.Tables[0].Rows[0]["Returned"]).Subtract(Convert.ToDateTime(money.Tables[0].Rows[0]["_Started"]));
                double time = datetime.TotalHours;

                total = total + (price * time);
            }
            decimal sum = Convert.ToDecimal(total);
            sum = Decimal.Round(sum, 2);

            MessageBox.Show("Rental Cost: $" + sum.ToString());

        }

        private void StartRental_Click(object sender, EventArgs e)
        {
            if (!fileExists(this.Filename.Text))
                return;
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);

            //Get Data from Primary Data table
            string primeData = this.PrimeData.Text;
            var IDs = this.RentalBox.CheckedItems;
            string hours = this.RentalDuration.Text;

            //Check if Data exists
            if (primeData == "" || IDs.Count == 0 || hours == "")
            {
                MessageBox.Show("One or more fields are blank...");
                return;
            }

            //Parse the data
            double expectedHours = Convert.ToDouble(hours);
            string[] name = primeData.Split(',');
            List<string> BIDs = new List<string>();
            foreach (string id in IDs)
            {
                BIDs.Add(id.Substring(0, 4));
            }

            //Check if Data is valid
            if (expectedHours <= 0)
            {
                MessageBox.Show("Please enter an expected rental time greater than 0");
                return;
            }

            foreach (string id in BIDs)
            {
                if (!bikeExists(Int32.Parse(id)))
                    return;
            }

            foreach (string id in BIDs)
            {
                if (!bikeAvailable(Int32.Parse(id)))
                    return;
            }

            string custIDSql = string.Format(@"
            SELECT CID
            FROM Customer
            WHERE LastName = '{0}' AND FirstName = '{1}';",
            name[0], name[1]);

            var custIDOBJ = data.ExecuteScalarQuery(custIDSql);
            int custID = Int32.Parse(custIDOBJ.ToString());

            string custSql = string.Format(@"
            SELECT RentingOut
            FROM Customer
            WHERE CID = {0};",
            custID);

            var ds = data.ExecuteScalarQuery(custSql);

            if (ds.Equals(true))
            {
                MessageBox.Show("Customer is currently renting out a bike...");
                return;
            }

            string bu = string.Format(@"
                UPDATE Bike
                    SET RentedOut = 1
                    WHERE BID = {0};",
                Int32.Parse(BIDs[0]));

            var db = data.ExecuteActionQuery(bu, null, false);

            //Create the Rental entry and modify the Customer and Bike entries
            foreach (string id in BIDs)
            {
                string bikeUpdate = string.Format(@"
                UPDATE Bike
                    SET RentedOut = 1
                    WHERE BID = {0};",
                Int32.Parse(id));

                data.ExecuteActionQuery(bikeUpdate, db, false);
            }

            string custUpdate = string.Format(@"
            UPDATE Customer
                SET RentingOut = 1
                WHERE CID = {0};",
            custID);

            data.ExecuteActionQuery(custUpdate, db, false);
            
            foreach(string id in BIDs)
            {
                string createRental = string.Format(@"
                INSERT INTO
                    Rentals(ExpectedHours, _Started, CID, BID)
                    Values({0},GetDate(),{1},{2});",
                    hours, custID, Int32.Parse(id));

                data.ExecuteActionQuery(createRental, db, true);

                string getRentalID = string.Format(@"
                SELECT TOP 1 RID
                FROM Rentals
                ORDER BY RID DESC;");

                var rentID = data.ExecuteScalarQuery(getRentalID);

                MessageBox.Show("Rental ID: " + rentID.ToString());
            }
        }

        private void Filename_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrimeData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fileExists(this.Filename.Text))
                return;
            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);

            string listData = this.PrimeData.Text;

            //Check to see whether Primary Data Table contains Bikes or Customers or is empty
            if (listData == "")
                return;
            if (listData.Contains("BID: "))
            {
                //Data is a Bike so get Bike data from Bike table
                SecData.Items.Clear();

                listData = listData.Substring(5);

                string dispData = string.Format(@"
                SELECT Bike_Type._Description, Bike.YearDeployed, Bike_Type.Price, Bike.RentedOut
                FROM Bike WITH (INDEX(BTID_Index))
                INNER JOIN Bike_Type ON Bike_Type.BTID = Bike.BTID
                WHERE BID = {0};",
                listData);

                DataSet ds = new DataSet();
                ds = data.ExecuteNonScalarQuery(dispData);

                SecData.Items.Add("Type: " + ds.Tables[0].Rows[0]["_Description"].ToString());
                SecData.Items.Add("Year: " + ds.Tables[0].Rows[0]["YearDeployed"].ToString());
                SecData.Items.Add("Price: $" + ds.Tables[0].Rows[0]["Price"].ToString());

                if (ds.Tables[0].Rows[0]["RentedOut"].ToString() == "False")
                {
                    SecData.Items.Add("Status: Available");
                }
                else
                {
                    SecData.Items.Add("Status: Unavailable");

                    string rentData = string.Format(@"
                    SELECT _Started, ExpectedHours
                    FROM Rentals WITH (INDEX(BID_Index))
                    WHERE BID = {0} AND Returned IS NULL;",
                    listData);

                    DataSet rds = new DataSet();
                    rds = data.ExecuteNonScalarQuery(rentData);
                    DateTime start = Convert.ToDateTime(rds.Tables[0].Rows[0]["_Started"]);
                    DateTime end = start.AddHours(Convert.ToDouble(rds.Tables[0].Rows[0]["ExpectedHours"]));

                    SecData.Items.Add("Start: " + start.ToString());
                    SecData.Items.Add("Expected End: " + end.ToString());
                }


            }
            else if (listData.Contains(" "))
                return;
            else
            {
                //Data is a Customer so get Customer data from Customer table
                SecData.Items.Clear();

                string[] names = listData.Split(',');
                string last = names[0];
                string first = names[1];

                string dispData = string.Format(@"
                SELECT CID, Email, RentingOut
                FROM Customer
                WHERE FirstName = '{0}' AND LastName = '{1}';",
                first, last);

                DataSet ds = new DataSet();
                ds = data.ExecuteNonScalarQuery(dispData);

                int CID = Int32.Parse(ds.Tables[0].Rows[0]["CID"].ToString());

                SecData.Items.Add("ID: " + ds.Tables[0].Rows[0]["CID"].ToString());
                SecData.Items.Add("Email: " + ds.Tables[0].Rows[0]["Email"].ToString());

                if (ds.Tables[0].Rows[0]["RentingOut"].ToString() == "False")
                {
                    SecData.Items.Add("Status: Available");
                }
                else
                {
                    SecData.Items.Add("Status: Unavailable");

                    string rentData = string.Format(@"
                    SELECT RID, _Started, ExpectedHours
                    FROM Rentals WITH (INDEX(CID_Index))
                    WHERE CID = {0} AND Returned IS NULL;",
                    CID);

                    DataSet rds = new DataSet();
                    rds = data.ExecuteNonScalarQuery(rentData);
                    DateTime start = Convert.ToDateTime(rds.Tables[0].Rows[0]["_Started"]);
                    DateTime end = start.AddHours(Convert.ToDouble(rds.Tables[0].Rows[0]["ExpectedHours"]));

                    SecData.Items.Add("Bikes Rented: " + rds.Tables[0].Rows.Count.ToString());
                    SecData.Items.Add("Start: " + start.ToString());
                    SecData.Items.Add("Expected End: " + end.ToString());
                }
            }
        }

        private void ResetDatabase_Click(object sender, EventArgs e)
        {
            if (!fileExists(this.Filename.Text))
                return;

            DataAccessTier.Data data = new DataAccessTier.Data(this.Filename.Text);

            string resetCust = string.Format(@"
            UPDATE Customer
            SET RentingOut = 0;");

            string resetBike = string.Format(@"
            UPDATE Bike
            SET RentedOut = 0;");

            string resetRent = string.Format(@"
            TRUNCATE TABLE Rentals;");

            List<string> sql = new List<string>();
            sql.Add(resetCust);
            sql.Add(resetBike);
            sql.Add(resetRent);

            data.ExecuteActionQuery(sql.ToArray(), "s");

            MessageBox.Show("Database reset...");
        }
    }
}
