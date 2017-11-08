using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    updateTable();
                }
                catch (Exception ex)
                {
                    resultLabel.Text = "<h2 class=\"text-danger\"> Unable to connect to database for orders, Error: " + ex.Message.ToString() + "</h2>";
                }

            }
        }

        protected void ordersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ordersGridView.Rows[index];

                var value = row.Cells[1].Text;
                var orderId = Guid.Parse(value);
                Domain.PizzaOrderManager.UpdateOrderCompletion(orderId);
            }
            catch (Exception ex)
            {
                resultLabel.Text = "<h2 class=\"text-danger\"> Unable to update order completion, Error: " + ex.Message.ToString() + "</h2>";
            }

            updateTable();
        }

        protected void updateTable()
        {
            try
            {
                var orders = Domain.PizzaOrderManager.GetOrders();
                var incompletedOrders = orders.Where(o => o.Completed != true);
                if (incompletedOrders.Count() == 0) {
                    resultLabel.Text = "<h2 class=\"text-success text-center\"> All orders are completed </h2>";
                } else
                {
                    resultLabel.Text = "";
                }
                ordersGridView.DataSource = incompletedOrders.ToList();
                ordersGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = "<h2 class=\"text-danger\"> Unable to connect to database for orders, Error: " + ex.Message.ToString() + "</h2>";
            }
        }
    }
}