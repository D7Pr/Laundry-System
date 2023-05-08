using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using MetroFramework.Forms;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Laundry_System
{
    internal partial class OriginalForm : MetroForm
    {
        private class OrderItem
        {
            public string ClothesType { get; set; }
            public string Service { get; set; }
            public int Quantity { get; set; }
            public decimal ServicePrice { get; set; }

            public decimal TotalPrice
            {
                get { return (ServicePrice * Quantity); }
            }
        }

        private readonly Dictionary<string, decimal> servicePrices = new Dictionary<string, decimal>
        {
            // Here the prices are constant because its likely not going to change in near future
            { "Wash", 2.00m },
            { "Dry", 2.00m },
            { "Wash & Dry", 4.00m }
        };

        private List<OrderItem> orderItems = new List<OrderItem>();

        public OriginalForm()
        {
            InitializeComponent();
            // Add the Form.Shown event handler
            this.Shown += OriginalForm_Shown;

            txtSquareMeters.Visible = false;  // Hide on form load
            cmbClothesType.SelectedIndexChanged += CmbClothesType_SelectedIndexChanged;

            // Set initial properties for txtCustomerName
            txtCustomerName.ForeColor = Color.FromArgb(128, 128, 128, 128);
            txtCustomerName.Text = "Enter Customer Name (Letters Only)";
            txtCustomerName.Font = new System.Drawing.Font(new FontFamily("Tahoma"), 8f);

            // Set initial properties for txtPhoneNumber
            txtPhoneNumber.ForeColor = Color.FromArgb(128, 128, 128, 128);
            txtPhoneNumber.Text = "Enter Phone Number (Numbers Only)";
            txtPhoneNumber.Font = new System.Drawing.Font(new FontFamily("Tahoma"), 8f);

            this.btnAdd.Click += new EventHandler(AddButton_Click);
            this.btnSubmit.Click += new EventHandler(SubmitButton_Click);
            this.btnRemove.Click += new EventHandler(RemoveButton_Click); // Added event handler
        }

        private void CmbClothesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cmbClothesType.SelectedItem?.ToString();
            ShowHideTextBox(selectedItem);
        }

        private void ShowHideTextBox(string selectedItem)
        {
            if (selectedItem == "Carpet" || selectedItem == "Curtain")
            {
                txtSquareMeters.Visible = true;
            }
            else
            {
                txtSquareMeters.Visible = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (cmbClothesType.SelectedItem == null || cmbService.SelectedItem == null || nudQuantity.Value < 1)
            {
                MessageBox.Show("Please make sure clothes type, service, and quantity are selected and valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedService = cmbService.SelectedItem.ToString();
            decimal selectedServicePrice = servicePrices[selectedService];
            if (cmbClothesType.SelectedItem.ToString() == "Curtain" || cmbClothesType.SelectedItem.ToString() == "Carpet")
            {
                string squareMeters = txtSquareMeters.Text;
                selectedServicePrice = Math.Round(selectedServicePrice * Convert.ToDecimal(squareMeters), 2);
                selectedServicePrice = selectedServicePrice * nudQuantity.Value;
            }
            // Here we choosed to make the prices multiplied by the original price of the service type
            switch (cmbClothesType.SelectedItem.ToString())
            {
                case "Wool Thobe":
                    selectedServicePrice *= 1.5m;
                    break;

                case "Shmogh":
                    selectedServicePrice *= 0.75m;
                    break;

                case "Ghutra":
                    selectedServicePrice *= 0.75m;
                    break;

                case "Shirt":
                    selectedServicePrice *= 0.75m;
                    break;

                case "Pant":
                    selectedServicePrice *= 1.75m;
                    break;

                case "Tie":
                    selectedServicePrice *= 0.5m;
                    break;

                case "Cap":
                    selectedServicePrice *= 0.5m;
                    break;

                case "Militery Suit":
                    selectedServicePrice *= 2.5m;
                    break;

                case "Over Coat":
                    selectedServicePrice *= 2.75m;
                    break;

                case "Men's Suit":
                    selectedServicePrice *= 2.5m;
                    break;

                case "Bisht":
                    selectedServicePrice *= 2.75m;
                    break;

                case "Furwah":
                    selectedServicePrice *= 3m;
                    break;

                case "Pyjama":
                    selectedServicePrice *= 1.75m;
                    break;

                case "Bath Robe":
                    selectedServicePrice *= 1.75m;
                    break;

                case "Towel":
                    selectedServicePrice *= 0.75m;
                    break;

                case "U. Shirt":
                    selectedServicePrice *= 0.5m;
                    break;

                case "Sarwal":
                    selectedServicePrice *= 1.75m;
                    break;

                case "U. Short":
                    selectedServicePrice *= 0.5m;
                    break;

                case "Socks (Pair)":
                    selectedServicePrice *= 0.5m;
                    break;

                case "Ladies Suit":
                    selectedServicePrice *= 3.5m;
                    break;

                case "Blouse":
                    selectedServicePrice *= 1.5m;
                    break;

                case "Skirt":
                    selectedServicePrice *= 2.5m;
                    break;

                case "Ladies Dress Long":
                    selectedServicePrice *= 3.75m;
                    break;

                case "Ladies Dress Short":
                    selectedServicePrice *= 4m;
                    break;

                case "Dress Pleated":
                    selectedServicePrice *= 3.5m;
                    break;

                case "Special Dress":
                    selectedServicePrice *= 4m;
                    break;

                case "Abaya":
                    selectedServicePrice *= 2.5m;
                    break;

                case "Baby Frock":
                    selectedServicePrice *= 2.75m;
                    break;

                case "Bed Sheet":
                    selectedServicePrice *= 2.5m;
                    break;

                case "Pillow":
                    selectedServicePrice *= 2m;
                    break;

                case "Pillow Cover":
                    selectedServicePrice *= 0.5m;
                    break;

                case "Bed Spread Cover":
                    selectedServicePrice *= 3m;
                    break;

                case "Blanket":
                    selectedServicePrice *= 3.5m;
                    break;

                case "Mattress":
                    selectedServicePrice *= 2.75m;
                    break;

                case "Curtain":
                    selectedServicePrice *= 2.5m;
                    break;

                case "Carpet":
                    selectedServicePrice *= 3m;
                    break;
            }
            selectedServicePrice = Math.Round(selectedServicePrice, 2);

            OrderItem item = new OrderItem
            {
                ClothesType = cmbClothesType.SelectedItem.ToString(),
                Service = selectedService,
                Quantity = Convert.ToInt32(nudQuantity.Value),
                ServicePrice = selectedServicePrice
            };
            orderItems.Add(item);
            UpdateDataGridView();
            ResetInputFields();
        }

        private void UpdateDataGridView()
        {
            dgvOrders.Rows.Clear();
            foreach (OrderItem item in orderItems)
            {
                int rowIndex = dgvOrders.Rows.Add(item.ClothesType, item.Service, item.ServicePrice, item.Quantity, item.TotalPrice);
                dgvOrders.Rows[rowIndex].Tag = item;
            }
        }

        private void ResetInputFields()
        {
            cmbClothesType.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;
            nudQuantity.Value = 1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Empty row cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in dgvOrders.SelectedRows)
            {
                OrderItem itemToRemove = row.Tag as OrderItem;
                orderItems.Remove(itemToRemove);
                dgvOrders.Rows.Remove(row);
            }
        }

        private PdfPCell GetCellPrimary(string text, float minimumHeight)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text))
            {
                MinimumHeight = minimumHeight,
                Padding = 5f, // Add padding to the cell
                HorizontalAlignment = Element.ALIGN_CENTER, // Center-align the text horizontally
                VerticalAlignment = Element.ALIGN_MIDDLE, // Center-align the text vertically
            };

            // Set cell background color
            cell.BackgroundColor = new BaseColor(224, 224, 224);

            // Set cell border
            cell.BorderColor = new BaseColor(128, 128, 128);
            cell.BorderWidth = 1f;

            return cell;
        }

        private PdfPCell GetCellSecondry(string text, float minimumHeightSec)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text))
            {
                MinimumHeight = minimumHeightSec,
                Padding = 2.5f, // Add padding to the cell
            };

            // Set cell border
            cell.BorderColor = new BaseColor(128, 128, 128);
            cell.BorderWidth = 1f;

            return cell;
        }

        private void GenerateInvoice(Customer customer, Order order)
        {
            // Setting the output file path and create the PDF writer
            string outputPath = GetOutputPath(customer);

            NumberFormatInfo saudiArabianCulture = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            saudiArabianCulture.CurrencySymbol = "SAR ";

            // Setting up the document and page layout
            using (Document document = new Document(PageSize.LETTER, 50f, 50f, 25f, 25f))
            {
                if (string.IsNullOrEmpty(outputPath))
                {
                    return;
                }

                PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

                // Open the document
                document.Open();

                // Adding laundry information
                string laundryName = "DCC Laundry";
                string laundryAddress = "Dammam, DCC";
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string currentTime = DateTime.Now.ToString("hh:mm:ss tt");
                document.Add(new Paragraph($"{laundryName}"));
                document.Add(new Paragraph($"{laundryAddress}"));
                document.Add(new Paragraph($"Date: {currentDate} \nTime: {currentTime}"));

                // Adding a separator
                document.Add(new Chunk(new LineSeparator()));

                // Adding customer information
                document.Add(new Paragraph($"Customer Name: {customer.Name}"));
                document.Add(new Paragraph($"Phone Number: {customer.PhoneNumber}"));

                // Adding the list of orders as a table
                PdfPTable table = new PdfPTable(5)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10f,
                    SpacingAfter = 10f
                };
                table.SetWidths(new float[] { 2, 1, 1, 2, 1 });

                // Set the minimum height for table cells
                float cellMinimumHeight = 30f;

                // Adding table headers
                table.AddCell(GetCellPrimary("Clothes Type", cellMinimumHeight));
                table.AddCell(GetCellPrimary("Service", cellMinimumHeight));
                table.AddCell(GetCellPrimary("Quantity", cellMinimumHeight));
                table.AddCell(GetCellPrimary("Price per Unit", cellMinimumHeight));
                table.AddCell(GetCellPrimary("Total", cellMinimumHeight));

                float minimumHeightSec = 15f;
                // Adding order items to the table
                decimal total = 0;
                foreach (var item in order.OrderItems)
                {
                    decimal orderPrice = item.ServicePrice;
                    int orderQuantity = item.Quantity;

                    decimal orderTotal = orderPrice * orderQuantity;
                    total += orderTotal;

                    string formattedOrderPrice = orderPrice.ToString("C", saudiArabianCulture);
                    string formattedOrderTotal = orderTotal.ToString("C", saudiArabianCulture);

                    table.AddCell(GetCellSecondry(item.ClothesType, minimumHeightSec));
                    table.AddCell(GetCellSecondry(item.Service, minimumHeightSec));
                    table.AddCell(GetCellSecondry(orderQuantity.ToString(), minimumHeightSec));
                    table.AddCell(GetCellSecondry(formattedOrderPrice, minimumHeightSec));
                    table.AddCell(GetCellSecondry(formattedOrderTotal, minimumHeightSec));
                }

                // Calculate the total price before VAT and the VAT amount
                decimal vatRate = 0.15m;
                decimal totalPriceBeforeVat = total / (1 + vatRate);
                decimal vatAmount = total - totalPriceBeforeVat;

                // Adding total price before VAT row
                PdfPCell emptyCell = new PdfPCell { Border = PdfPCell.NO_BORDER };
                emptyCell.Colspan = 3;
                table.AddCell(emptyCell);

                PdfPCell totalPriceBeforeVatLabelCell = new PdfPCell(new Phrase("Total Price Before VAT: ")) { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.NO_BORDER };
                table.AddCell(totalPriceBeforeVatLabelCell);

                string formattedTotalPriceBeforeVat = totalPriceBeforeVat.ToString("C", saudiArabianCulture);
                PdfPCell totalPriceBeforeVatValueCell = new PdfPCell(new Phrase(formattedTotalPriceBeforeVat)) { Border = PdfPCell.NO_BORDER };
                table.AddCell(totalPriceBeforeVatValueCell);

                // Adding VAT amount row
                table.AddCell(emptyCell);

                PdfPCell vatAmountLabelCell = new PdfPCell(new Phrase("Total VAT Amount 15%: ")) { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.NO_BORDER };
                table.AddCell(vatAmountLabelCell);

                string formattedVatAmount = vatAmount.ToString("C", saudiArabianCulture);
                PdfPCell vatAmountValueCell = new PdfPCell(new Phrase(formattedVatAmount)) { Border = PdfPCell.NO_BORDER };
                table.AddCell(vatAmountValueCell);

                // Adding the total price row
                emptyCell.Border = PdfPCell.BOTTOM_BORDER;
                table.AddCell(emptyCell);

                PdfPCell totalLabelCell = new PdfPCell(new Phrase("Total Price After VAT: ")) { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.BOTTOM_BORDER };
                table.AddCell(totalLabelCell);

                string formattedTotal = total.ToString("C", saudiArabianCulture);
                PdfPCell totalValueCell = new PdfPCell(new Phrase(formattedTotal)) { Border = PdfPCell.BOTTOM_BORDER };
                table.AddCell(totalValueCell);

                document.Add(table);

                // Close the document
                document.Close();
            }

            MessageBox.Show($"Invoice generated: {outputPath}", "Invoice Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string GetOutputPath(Customer customer)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Invoice_{customer.Id}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            Regex nameRegex = new Regex("^[a-zA-Z\\s]+$");
            Regex phoneRegex = new Regex("^\\+?[0-9]+$");

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Please enter the customer's name and phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!nameRegex.IsMatch(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter a valid name using only letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!phoneRegex.IsMatch(txtPhoneNumber.Text))
            {
                MessageBox.Show("Please enter a valid phone number using only numbers, (it can contain an optional '+' sign)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (orderItems.Count == 0)
            {
                MessageBox.Show("Please add at least one item to the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read the configuration from the appsettings.json file
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the database settings from the configuration
            var settings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();

            // Create a new MongoDB context
            var dbContext = new MongoDbContext(settings);

            // Check if the customer already exists
            var existingCustomer = await dbContext.FindCustomerByPhoneNumberAsync(txtPhoneNumber.Text);

            ObjectId customerId;
            if (existingCustomer == null)
            {
                // Create a new customer object
                var customer = new Customer
                {
                    Name = txtCustomerName.Text,
                    PhoneNumber = txtPhoneNumber.Text
                };

                // Adding and save the customer data to the database
                await dbContext.Customers.InsertOneAsync(customer);
                customerId = customer.Id;
            }
            else
            {
                // Update the existing customer's name in case it was changed
                var update = Builders<Customer>.Update.Set(c => c.Name, txtCustomerName.Text);
                await dbContext.Customers.UpdateOneAsync(c => c.Id == existingCustomer.Id, update);
                customerId = existingCustomer.Id;
            }

            decimal orderTotal = 0;

            Order dbOrder = new Order
            {
                CustomerId = customerId.ToString(),
                OrderDateTime = DateTime.Now,
                OrderItems = new List<Laundry_System.OrderItem>(),
                OrderTotal = orderTotal.ToString()
            };

            // Adding the order items to a separate Orders collection
            foreach (OrderItem item in orderItems)
            {
                dbOrder.OrderItems.Add(new Laundry_System.OrderItem
                {
                    ClothesType = item.ClothesType,
                    Service = item.Service,
                    Quantity = item.Quantity,
                    ServicePrice = item.ServicePrice,
                    Total = item.TotalPrice,
                });
                // Calculate the total of all items
                orderTotal += item.TotalPrice;
            }

            // Update the OrderTotal property after calculation
            dbOrder.OrderTotal = orderTotal.ToString();

            await dbContext.Orders.InsertOneAsync(dbOrder);

            // Get the phone number from the input field
            string phoneNumber = txtPhoneNumber.Text;
            MessageBox.Show("Order submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Generate the invoice
            var invoiceCustomer = existingCustomer ?? new Customer { Id = customerId, Name = txtCustomerName.Text, PhoneNumber = txtPhoneNumber.Text };
            GenerateInvoice(invoiceCustomer, dbOrder);

            // Clear the form and start a new order
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            orderItems.Clear();
            UpdateDataGridView();
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "Enter Customer Name (Letters Only)")
            {
                txtCustomerName.Text = string.Empty;
                txtCustomerName.ForeColor = SystemColors.WindowText; // Setting the text color to the default
                txtCustomerName.Font = new System.Drawing.Font(new FontFamily("Tahoma"), 9.75f);
            }
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                txtCustomerName.ForeColor = Color.FromArgb(128, 128, 128, 128); // Setting the text color to semi-transparent
                txtCustomerName.Text = "Enter Customer Name (Letters Only)";
                txtCustomerName.Font = new System.Drawing.Font(new FontFamily("Tahoma"), 8f);
            }
        }

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCustomerName.Text == "Enter Customer Name (Letters Only)")
            {
                e.Handled = true; // Block the key press
            }
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "Enter Phone Number (Numbers Only)")
            {
                txtPhoneNumber.Text = string.Empty;
                txtPhoneNumber.ForeColor = SystemColors.WindowText;
                txtPhoneNumber.Font = new System.Drawing.Font(new FontFamily("Tahoma"), 9.75f);
            }
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                txtPhoneNumber.ForeColor = Color.FromArgb(128, 128, 128, 128);
                txtPhoneNumber.Text = "Enter Phone Number (Numbers Only)";
                txtPhoneNumber.Font = new System.Drawing.Font(new FontFamily("Tahoma"), 8f);
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPhoneNumber.Text == "Enter Phone Number (Numbers Only)")
            {
                e.Handled = true;
            }
        }

        private void OriginalForm_Shown(object sender, EventArgs e)
        {
            // Here we did this focus because the form when starts it show all watermarks, before it was going direct to the first textbox so it was not correct
            label1.Focus();
        }
    }
}