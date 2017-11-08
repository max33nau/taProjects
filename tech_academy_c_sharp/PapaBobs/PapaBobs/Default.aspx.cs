using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PapaBobs
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Domain.PizzaDetails PizzaDetails = new Domain.PizzaDetails();
                InitPizzaSizeChoices(PizzaDetails);
                InitPizzaCrustChoices(PizzaDetails);
                InitPizzaToppingChoices(PizzaDetails);
                InitPaymentTypesChoices();
            }

        }

        private void InitPizzaSizeChoices(Domain.PizzaDetails PizzaDetails)
        {
            foreach (var pizzaSize in PizzaDetails.Sizes)
            {
                string text = String.Format("{0} ({1} {2} - {3:C})", 
                    pizzaSize.SizeType, pizzaSize.Size.Circumfrence, 
                    pizzaSize.Size.Unit, pizzaSize.Price);
                sizeDropDownList.Items.Add(new ListItem() { Text = text,
                    Value = getValueToSet(pizzaSize.SizeType.ToString(), pizzaSize.Price.ToString())
                });
            }
        }

        private void InitPizzaCrustChoices(Domain.PizzaDetails PizzaDetails)
        {
            foreach (var pizzaCrust in PizzaDetails.Crusts)
            {
                string text;
                if (pizzaCrust.Price > 0) { text = String.Format("{0} (+ {1:C})", pizzaCrust.Crust, pizzaCrust.Price); }
                else { text = pizzaCrust.Crust.ToString(); }
                crustDropDownList.Items.Add(new ListItem() { Text = text,
                    Value = getValueToSet(pizzaCrust.Crust.ToString(), pizzaCrust.Price.ToString())
                }); // this is needed to trigger dropdown change for when they are same value
            }
        }

        private void InitPizzaToppingChoices(Domain.PizzaDetails PizzaDetails)
        {
            foreach (var pizzaTopping in PizzaDetails.Toppings)
            {
                string text;
                var toppingText = pizzaTopping.Topping.ToString().Replace('_', ' ');
                if (pizzaTopping.Price > 0)
                { text = String.Format("{0} (+ {1:C})", toppingText, pizzaTopping.Price); }
                else { text = toppingText; }
                toppingsCheckBoxList.Items.Add(
                    new ListItem() { Text = text,
                        Value = getValueToSet(pizzaTopping.Topping.ToString(), pizzaTopping.Price.ToString()),
                        Selected = false }
                );
            }
        }

        public void InitPaymentTypesChoices()
        {
            Domain.PaymentTypes PaymentTypes = new Domain.PaymentTypes();
            foreach (var payment in PaymentTypes.Types)
            {
                paymentTypesRadio.Items.Add(
                    new ListItem() { Text = payment.Payment.ToString(), Value = payment.Payment.ToString(), Selected = false }
                );
            }
        }

        protected void getTotalPrice(object sender, EventArgs e)
        {
            try
            {
                double totalPrice = 0;
                totalPrice += getPrice(sizeDropDownList.SelectedValue);
                totalPrice += getPrice(crustDropDownList.SelectedValue);
                foreach (ListItem topping in toppingsCheckBoxList.Items)
                {
                    if (topping.Selected) { totalPrice += getPrice(topping.Value); }
                }
                resultLabel.Text = String.Format("Total Price: {0:C}", totalPrice);
            } catch (Exception ex)
            {
                resultLabel.Text = "A error occured while trying to get total price. <br /> " + ex.Message;
            }

        }

        protected string getValueToSet(string type, string price) { return type + ':' + price; }

        protected string getValueType(string Value) {
            string stringValue = Value.Substring(0, Value.IndexOf(':'));
            return stringValue;
        }

        protected double getPrice(string Value)
        {
            string priceString = Value.Substring(Value.IndexOf(':') + 1);
            return double.Parse(priceString);
        }

        protected void submitOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var newOrder = new DTO.OrderCopy();
                newOrder.Completed = false;
                if (stringIsEmpty(nameTextBox.Text))
                    throw new DTO.Exceptions.InvalidOrderTextException("Name");
                if (stringIsEmpty(addressTextBox.Text))
                    throw new DTO.Exceptions.InvalidOrderTextException("Address");
                if (stringIsEmpty(phoneTextBox.Text))
                    throw new DTO.Exceptions.InvalidOrderTextException("Phone Number");
                newOrder.Name = nameTextBox.Text;
                newOrder.Address = addressTextBox.Text;
                newOrder.Phone = phoneTextBox.Text;
                newOrder.Notes = notesTextBox.Text;

                int zip;
                if(!Int32.TryParse(zipTextBox.Text, out zip))
                    throw new DTO.Exceptions.InvalidOrderNumberException("Zip code");
                newOrder.Zip = zip;

                string sizeType = getValueType(sizeDropDownList.SelectedValue);
                DTO.Enums.SizeType size;
                if (stringIsEmpty(sizeType) || !Enum.TryParse(sizeType, out size))
                    throw new DTO.Exceptions.InvalidOrderDropdownException("Size");
                newOrder.Size = size;

                string crustType = getValueType(crustDropDownList.SelectedValue);
                DTO.Enums.Crust crust;
                if (stringIsEmpty(crustType) || !Enum.TryParse(crustType, out crust))
                    throw new DTO.Exceptions.InvalidOrderDropdownException("Crust"); 
                newOrder.Crust = crust;

                string paymentType = paymentTypesRadio.SelectedValue;
                DTO.Enums.Payment payment;
                if (stringIsEmpty(paymentType) || !Enum.TryParse(paymentType, out payment))
                    throw new DTO.Exceptions.InvalidOrderRadioException("Payment type"); ;
                newOrder.PaymentType = payment;

                foreach (ListItem topping in toppingsCheckBoxList.Items)
                {
                    string toppingType = getValueType(topping.Value);
                    DTO.Enums.Topping pizzaTopping;
                    if (Enum.TryParse(toppingType, out pizzaTopping))
                    {
                        if (pizzaTopping == DTO.Enums.Topping.Green_Peppers)
                            newOrder.Green_Peppers = topping.Selected;
                        if (pizzaTopping == DTO.Enums.Topping.Sausage)
                            newOrder.Sausage = topping.Selected;
                        if (pizzaTopping == DTO.Enums.Topping.Pepperoni)
                            newOrder.Pepperoni = topping.Selected;
                        if (pizzaTopping == DTO.Enums.Topping.Green_Peppers)
                            newOrder.Green_Peppers = topping.Selected;
                    };
                }

                string totalPrice = resultLabel.Text.Substring(resultLabel.Text.IndexOf("$") + 1);
                double totalCost;
                if (!Double.TryParse(totalPrice, out totalCost)) return;
                newOrder.TotalCost = totalCost;

                Domain.PizzaOrderManager.AddOrder(newOrder);
                Server.Transfer("Success.aspx", true);

            }
            catch (DTO.Exceptions.InvalidOrderDropdownException ex)
            {
                resultLabel.Text = "<p class=\"bg-danger\"> Must select a " + ex.RequiredDropdownField + " from dropdown. </p>";
            }
            catch (DTO.Exceptions.InvalidOrderTextException ex)
            {
                resultLabel.Text = "<p class=\"bg-danger\"> Input field " + ex.RequiredTextField + " is required. </p>";
            }
            catch (DTO.Exceptions.InvalidOrderRadioException ex )
            {
                resultLabel.Text = "<p class=\"bg-danger\"> Must select a" + ex.RequiredRadioField + " from radio buttons. </p>";
            }
            catch (DTO.Exceptions.InvalidOrderNumberException ex )
            {
                resultLabel.Text = "<p class=\"bg-danger\"> " + ex.RequiredIntField + " must be a whole number. </p>";
            }
            catch (Exception ex)
            {
                resultLabel.Text = "<p class=\"text-danger\">There was a uncaught error, Error Message: "+ex.Message.ToString()+"  </p>";
            }


        }

        protected bool stringIsEmpty(string value)
        {
            return (value.Trim().Length == 0);
        }
    }
}

