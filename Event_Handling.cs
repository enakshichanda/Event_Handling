  /*Creating an application for TeamBuilder Ltd,that provides team building events in locations across Ireland. 
 * The purpose of this application is to enable the companies front of house sales team to generate quotations and 
 * process bookings for these events.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //form load requirements
            InitializeComponent();
            choiceGroupbox.Visible = false;
            selectionGroupbox.Visible = false;
            summaryGroupbox.Visible = false;
            SummaryButton.Visible = false;
            clearButton.Visible = false;
            displayButton.Visible = false;
            displayUserNameLabel.Visible = false;
            userNameTextbox.Focus();

        }

        int loginTimes = 0;//counter variable for user login
        int maxTry = 3;//variable declared for maximum number of password re-try
        const string PASSWORD = "iLuvVisualC#"; 
        

        //variables declared for selecting and calculating events and event prices
        string selectedEvent;
        int eventDays;
        int eventPrice;

        //variables declared for selecting and calculating location prices.
        string selectedLocation;
        int lodgingFee;
        
        //variables declared to calculate meal and cetificate values.
        decimal mealValue;
        decimal printCertificateValue;

        //variables declared to be used in switch case for selecting particular values
        int eventsDetails;
        int locationDetails;

        //Counter value declarations
        int numberOfRegistrations = 0;
        int totalRegistrationPrice = 0;
        int totalLodgingPrice = 0;
        decimal totalMealPrice = 0;
        decimal totalCertificatePrice = 0;

        //Constants declaration for calculating meal values
        const decimal FULL_MEAL_VALUE = 49.50m;
        const decimal HALF_MEAL_VALUE = 37.50m;
        const decimal BREAKFAST_MEAL_VALUE = 12;
        const decimal NO_MEAL_VALUE = 0;

        //Constants declaration for calculating cretificate value
        const decimal CERTIFICATE_VALUE= 9.95m;

        //Constants declaration for event names
        const string EVENT_ONE = "Murder Mystery Weekend";
        const string EVENT_TWO = "CSI Weekends";
        const string EVENT_THREE = "The Great Outdoors";
        const string EVENT_FOUR = "The Chase";
        const string EVENT_FIVE = "Digital Refresh";

        //Constants declaration for event duration days
        const int EVENT_DURATION_ONE = 2;
        const int EVENT_DURATION_TWO = 3;
        const int EVENT_DURATION_THREE = 4;
        const int EVENT_DURATION_FOUR = 6;
        const int EVENT_DURATION_FIVE = 2;

        //Constants declaration for event registration fee
        const int EVENT_REGISTRATION_FEE_ONE = 600;
        const int EVENT_REGISTRATION_FEE_TWO = 1000;
        const int EVENT_REGISTRATION_FEE_THREE = 1500;
        const int EVENT_REGISTRATION_FEE_FOUR = 1800;
        const int EVENT_REGISTRATION_FEE_FIVE = 599;

        //Constants declaration for event location
        const string LOCATION_NAME_ONE = "Dublin";
        const string LOCATION_NAME_TWO = "Galway";
        const string LOCATION_NAME_THREE = "Cork";
        const string LOCATION_NAME_FOUR = "Belfast";
        const string LOCATION_NAME_FIVE = "Belmullet";

        //Constants declaration for calculating location wise lodging fees
        const int LOCATION_LODGINGFEE_ONE = 165;
        const int LOCATION_LODGINGFEE_TWO = 225;
        const int LOCATION_LODGINGFEE_THREE = 250;
        const int LOCATION_LODGINGFEE_FOUR = 95;
        const int LOCATION_LODGINGFEE_FIVE = 305;


        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            //validation for empty username and password
            if (userNameTextbox.Text == "" || passwordTextbox.Text == "")
            {
                MessageBox.Show("Please enter your username and Password");
                choiceGroupbox.Visible = false;
                userNameTextbox.Focus();

            }

            else
            {
                //password validation for the constant value
                if (passwordTextbox.Text == PASSWORD)
                {
                    loginTimes = 0;

                    choiceGroupbox.Visible = true;
                    userGroupbox.Visible= false;
                    selectionGroupbox.Visible = false;
                    noMealRadioButton.Visible = false;
                    clearButton.Visible = true;
                    displayButton.Visible = true;
                    SummaryButton.Visible = true;
                    displayUserNameLabel.Visible = true;
                    displayUserNameLabel.Text = "Welcome " +userNameTextbox.Text+".";

                }
                else
                {
                    //password validation when user tries 4 wrong passwords.
                    if (loginTimes == maxTry)
                    {
                        this.Close();
                        System.Windows.Forms.Application.ExitThread();
                        return;
                    }
                    MessageBox.Show("Attempt left:"+(maxTry-loginTimes)+"\nPlease enter correct password as sent on your email", "Warning",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);

                    passwordTextbox.Focus();
                    passwordTextbox.SelectAll();
                    loginTimes++;

                }
            }
        }

        
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            //switch case condition to choose a particular event from the list
            eventsDetails = eventsListbox.SelectedIndex;
            switch (eventsDetails)
            {
                case 0:
                    selectedEvent = EVENT_ONE;
                    eventDays = EVENT_DURATION_ONE;
                    eventPrice = EVENT_REGISTRATION_FEE_ONE;
                    break;
                case 1:
                    selectedEvent = EVENT_TWO;
                    eventDays = EVENT_DURATION_TWO;
                    eventPrice = EVENT_REGISTRATION_FEE_TWO;
                    break;
                case 2:
                    selectedEvent = EVENT_THREE;
                    eventDays = EVENT_DURATION_THREE;
                    eventPrice = EVENT_REGISTRATION_FEE_THREE;
                    break;
                case 3:
                    selectedEvent = EVENT_FOUR;
                    eventDays = EVENT_DURATION_FOUR;
                    eventPrice = EVENT_REGISTRATION_FEE_FOUR;
                    break;
                case 4:
                    selectedEvent = EVENT_FIVE;
                    eventDays = EVENT_DURATION_FIVE;
                    eventPrice = EVENT_REGISTRATION_FEE_FIVE;
                    break;
                default:
                    //Message box prompt when user doesn't select an event
                    MessageBox.Show("Please select Event", "Warning",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
            locationDetails = locationListbox.SelectedIndex;
            switch (locationDetails)
            {
                //switch case condition to choose a particular location for the event from the list
                case 0:
                    selectedLocation = LOCATION_NAME_ONE;
                    lodgingFee = LOCATION_LODGINGFEE_ONE;
                    break;
                case 1:
                    selectedLocation = LOCATION_NAME_TWO;
                    lodgingFee = LOCATION_LODGINGFEE_TWO;
                    break;
                case 2:
                    selectedLocation = LOCATION_NAME_THREE;
                    lodgingFee = LOCATION_LODGINGFEE_THREE;
                    break;
                case 3:
                    selectedLocation = LOCATION_NAME_FOUR;
                    lodgingFee = LOCATION_LODGINGFEE_FOUR;
                    break;
                case 4:
                    selectedLocation = LOCATION_NAME_FIVE;
                    lodgingFee = LOCATION_LODGINGFEE_FIVE;
                    break;
                default:
                    //Message box prompt when user doesn't select a location
                    MessageBox.Show("Please select Location", "Warning",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
           
             //Condition check for event and location once they are chosen from the listbox
 
            if ((eventsListbox.SelectedIndex != -1) && (locationListbox.SelectedIndex != -1))
            {
                
                selectionGroupbox.Visible = true;
                noMealRadioButton.Visible = true;

                eventNameDisplayLabel.Text = "Selected Event is " + selectedEvent + " costing " + "\u20AC" + eventPrice * eventDays;
                locationNameDisplayLabel.Text = "Location selected is " + selectedLocation + " which costs " + "\u20AC" + lodgingFee * eventDays;

                //selection of meal type from radio buttons and meal values which are constant
                if (fullMealRadioButton.Checked == true)
                    mealValue = FULL_MEAL_VALUE;
               
                if (halfMealRadioButton.Checked == true)
                    mealValue = HALF_MEAL_VALUE;
                
                if (breakfastRadioButton.Checked == true)
                    mealValue = BREAKFAST_MEAL_VALUE;
                
                if (noMealRadioButton.Checked == true)
                    mealValue = NO_MEAL_VALUE;

                totalMealPrice = totalMealPrice + mealValue * eventDays;

                //Checkbox condition for printing certificate where certificate value is constant
                if (yesCheckbox.Checked)
                    printCertificateValue = CERTIFICATE_VALUE;
                else
                    printCertificateValue = 0;

                //calculation performed for total meal and certificate values.
                mealDisplayLabel.Text = "Your meal price is " + mealValue * eventDays;
                certificateDisplayLabel.Text = "The certificate printing cost is "+ "\u20AC" + printCertificateValue;

                //calculation for total booking cost per user
                decimal totalCost = mealValue* eventDays + printCertificateValue;
                decimal totalCost2 = (eventPrice * eventDays) + (lodgingFee * eventDays) + totalCost;
                totalCostLabel.Text = "Total cost for your booking is "+ "\u20AC" + totalCost2;
            }

        }

        private void bookSelectionButton_Click(object sender, EventArgs e)
        {
            //calculation performed for total number of overall registrations in a day
            numberOfRegistrations++;
            totalRegistrationPrice = totalRegistrationPrice + eventPrice * eventDays; 
            totalLodgingPrice = totalLodgingPrice + lodgingFee * eventDays;
            totalCertificatePrice = totalCertificatePrice + printCertificateValue;
            MessageBox.Show(selectedLocation + " has been booked for you at "+ selectedEvent + ". "+ totalCostLabel.Text
  , "Booking Confirmed",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            
           
            bookSelectionButton.Enabled = false;
            displayButton.Enabled = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //allows a new user to login and process his booking
            userGroupbox.Visible = true;
            userGroupbox.Enabled = true;
            choiceGroupbox.Visible = false;
            selectionGroupbox.Visible = false;
            SummaryButton.Visible = false;
            summaryGroupbox.Visible = false;
            clearButton.Enabled = true;
            displayButton.Visible = false;
            userNameTextbox.Text = "";
            passwordTextbox.Text = "";
            eventsListbox.SelectedIndex = -1;
            locationListbox.SelectedIndex = -1;
            breakfastRadioButton.Checked = false;
            fullMealRadioButton.Checked = false;
            halfMealRadioButton.Checked = false;
            noMealRadioButton.Checked = false;
            yesCheckbox.Checked = false;
            selectionGroupbox.Enabled = true;
            choiceGroupbox.Enabled = true;
            userNameTextbox.Focus();
            bookSelectionButton.Enabled = true;
            displayButton.Enabled = true;
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            //Summary showing the total number of bookings in a day.
            totalBookingsLabel.Text = numberOfRegistrations.ToString();
            totalLodgingPriceLabel.Text = "\u20AC" +totalLodgingPrice.ToString();
            totalRegistrationFeesLabel.Text = "\u20AC" +totalRegistrationPrice.ToString();
            totalAverageLabel.Text= "\u20AC"+((totalRegistrationPrice+totalLodgingPrice)/numberOfRegistrations).ToString();
            totalOptionalCostLabel.Text = "\u20AC"+(totalMealPrice + totalCertificatePrice).ToString();
            summaryGroupbox.Visible = true;
            selectionGroupbox.Visible = false;
            choiceGroupbox.Visible = false;
            displayUserNameLabel.Visible = false;

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //exits the application and the background threads.
            this.Close();
            System.Windows.Forms.Application.ExitThread();
        }

        private void userNameTextbox_MouseHover(object sender, EventArgs e)
        { 
            //Mouse hover for entering user name
            ToolTip t1 = new ToolTip();
            t1.Active = true;
            t1.AutoPopDelay = 2000;
            t1.InitialDelay = 400;
            t1.IsBalloon = true;
            t1.ToolTipIcon = ToolTipIcon.Info;
            t1.SetToolTip(userNameTextbox, "Please enter user name");
        }

        private void passwordTextbox_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover for entering password
            ToolTip t2 = new ToolTip();
            t2.Active = true;
            t2.AutoPopDelay = 2000;
            t2.InitialDelay = 400;
            t2.IsBalloon = true;
            t2.ToolTipIcon = ToolTipIcon.Info;
            t2.SetToolTip(passwordTextbox, "Please enter password as given");
        }

        private void displayButton_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover for showing the final display of selection
            ToolTip t4 = new ToolTip();
            t4.Active = true;
            t4.AutoPopDelay = 2000;
            t4.InitialDelay = 400;
            t4.IsBalloon = true;
            t4.ToolTipIcon = ToolTipIcon.Info;
            t4.SetToolTip(displayButton, "Click to display your final selection");
        }

        private void bookSelectionButton_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover for clicking the book button to confirm the booking
            ToolTip t3 = new ToolTip();
            t3.Active = true;
            t3.AutoPopDelay = 2000;
            t3.InitialDelay = 400;
            t3.IsBalloon = true;
            t3.ToolTipIcon = ToolTipIcon.Info;
            t3.SetToolTip(bookSelectionButton, "Click to confirm your booking.");
        }


        private void exitButton_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover to exit the application
            ToolTip t5 = new ToolTip();
            t5.Active = true;
            t5.AutoPopDelay = 2000;
            t5.InitialDelay = 400;
            t5.IsBalloon = true;
            t5.ToolTipIcon = ToolTipIcon.Info;
            t5.SetToolTip(exitButton, "Click to close the application");
        }

        private void clearButton_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover for clear the application for entering new details
            ToolTip t6 = new ToolTip();
            t6.Active = true;
            t6.AutoPopDelay = 2000;
            t6.InitialDelay = 400;
            t6.IsBalloon = true;
            t6.ToolTipIcon = ToolTipIcon.Info;
            t6.SetToolTip(clearButton, "Click to clear the form and enter new user details ");
        }

        private void eventsListbox_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover to select an event from the listbox
            ToolTip t7 = new ToolTip();
            t7.Active = true;
            t7.AutoPopDelay = 2000;
            t7.InitialDelay = 400;
            t7.IsBalloon = true;
            t7.ToolTipIcon = ToolTipIcon.Info;
            t7.SetToolTip(eventPriceListbox, "Press select an event");
        }

        private void locationListbox_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover to select a location from the listbox
            ToolTip t8 = new ToolTip();
            t8.Active = true;
            t8.AutoPopDelay = 2000;
            t8.InitialDelay = 400;
            t8.IsBalloon = true;
            t8.ToolTipIcon = ToolTipIcon.Info;
            t8.SetToolTip(eventPriceListbox, "Press select a location of your choice");
        }

        private void SummaryButton_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover to check the total summary data in a day
            ToolTip t9 = new ToolTip();
            t9.Active = true;
            t9.AutoPopDelay = 2000;
            t9.InitialDelay = 400;
            t9.IsBalloon = true;
            t9.ToolTipIcon = ToolTipIcon.Info;
            t9.SetToolTip(SummaryButton, "Click here to check the total data Summary");
        }

        private void viewDetailsButton_MouseHover(object sender, EventArgs e)
        {
            //Mouse hover for user login
            ToolTip t10 = new ToolTip();
            t10.Active = true;
            t10.AutoPopDelay = 2000;
            t10.InitialDelay = 400;
            t10.IsBalloon = true;
            t10.ToolTipIcon = ToolTipIcon.Info;
            t10.SetToolTip(viewDetailsButton, "Click to Login");
        }
    }
}
