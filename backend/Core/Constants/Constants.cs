namespace Core.Constants
{
    public class Constants
    {
        #region CAR - Entity!
        public static string MSG_CAR_ADDED_SUCCESS { get; set; } = "Car added - Model {0} - Year: {1}";
        public static string MSG_CAR_ADDED_ERROR { get; set; } = "Error adding a car";
        public static string MSG_CAR_UPDATED_ERROR { get; set; } = "Error updating a car";
        public static string MSG_CAR_UPDATED_SUCCESS { get; set; } = "Car updated - Model {0} - Year: {1}";
        public static string MSG_CAR_DELETED_ERROR { get; set; } = "Error deleting a car";
        public static string MSG_CAR_DELETED_SUCCESS { get; set; } = "Car deleted - Model {0} - Year: {1}";
        #endregion

        #region CUSTOMER - Entity!
        public static string MSG_CUSTOMER_ADDED_SUCCESS { get; set; } = "Customer added - Name {0} - Document: {1}";
        public static string MSG_CUSTOMER_ADDED_ERROR { get; set; } = "Error adding a customer";
        public static string MSG_CUSTOMER_UPDATED_SUCCESS { get; set; } = "Customer updated - Name {0} - Document: {1}";
        public static string MSG_CUSTOMER_UPDATED_ERROR { get; set; } = "Error updating a customer";
        public static string MSG_CUSTOMER_DELETED_ERROR { get; set; } = "Error deleting a customer";
        public static string MSG_CUSTOMER_DELETED_SUCCESS { get; set; } = "Customer deleted - Name {0} - Document: {1}";
        #endregion

        #region DOCUMENT - Entity!
        public static string MSG_DOCUMENT_ADDED_SUCCESS { get; set; } = "Document added - Description: {0}";
        public static string MSG_DOCUMENT_ADDED_ERROR { get; set; } = "Error adding a document";
        public static string MSG_DOCUMENT_UPDATED_SUCCESS { get; set; } = "Document updated - Description: {0}";
        public static string MSG_DOCUMENT_UPDATED_ERROR { get; set; } = "Error updating a document";
        public static string MSG_DOCUMENT_DELETED_SUCCESS { get; set; } = "Document deleted - Description: {0}";
        public static string MSG_DOCUMENT_DELETED_ERROR { get; set; } = "Error deleting a document";
        #endregion

        #region PAYTYPE - Entity!
        public static string MSG_PAYTYPE_ADDED_SUCCESS { get; set; } = "Payment type added - Name: {0}";
        public static string MSG_PAYTYPE_ADDED_ERROR { get; set; } = "Error adding a payment type";
        public static string MSG_PAYTYPE_UPDATED_SUCCESS { get; set; } = "Payment type updated - Name: {0}";
        public static string MSG_PAYTYPE_UPDATED_ERROR { get; set; } = "Error updating a payment type";
        public static string MSG_PAYTYPE_DELETED_SUCCESS { get; set; } = "Payment type deleted - Name: {0}";
        public static string MSG_PAYTYPE_DELETED_ERROR { get; set; } = "Error deleting a payment type";
        #endregion

        #region PRICE - Entity!
        public static string MSG_PRICE_ADDED_SUCESS { get; set; } = "Price added - Value: {0} - Discount: {1} - Accepts discount: {2}";
        public static string MSG_PRICE_ADDED_ERROR { get; set; } = "Error adding a price";
        public static string MSG_PRICE_UPDATED_SUCESS { get; set; } = "Price updated - Value: {0} - Discount: {1} - Accepts discount: {2}";
        public static string MSG_PRICE_UPDATED_ERROR { get; set; } = "Error updating a price";
        public static string MSG_PRICE_DELETED_SUCESS { get; set; } = "Price deleted - Value: {0} - Discount: {1} - Accepts discount: {2}";
        public static string MSG_PRICE_DELETED_ERROR { get; set; } = "Error deleting a price";
        #endregion

        #region RENT - Entity!
        public static string MSG_RENT_ADDED_SUCCESS { get; set; } = "Rental added - CustomerId: {0} - CarId: {1} - Day: {2} - DaysRemaining: {3} - PayTypeId: {4} - PriceId: {5}";
        public static string MSG_RENT_ADDED_ERROR { get; set; } = "Error adding a rental";
        public static string MSG_RENT_UPDATED_SUCCESS { get; set; } = "Rental updated - CustomerId: {0} - CarId: {1} - Day: {2} - DaysRemaining: {3} - PayTypeId: {4} - PriceId: {5}";
        public static string MSG_RENT_UPDATED_ERROR { get; set; } = "Error updating a rental";
        public static string MSG_RENT_DELETED_SUCCESS { get; set; } = "Rental deleted - CustomerId: {0} - CarId: {1} - Day: {2} - DaysRemaining: {3} - PayTypeId: {4} - PriceId: {5}";
        public static string MSG_RENT_DELETED_ERROR { get; set; } = "Error deleting a rental";
        #endregion

        #region USER - Entity!
        public static string MSG_USER_ADDED_SUCCESS { get; set; } = "User added - UserId: {0} - Name: {1}";
        public static string MSG_USER_ADDED_ERROR { get; set; } = "Error adding a user";
        public static string MSG_USER_UPDATED_SUCCESS { get; set; } = "User updated - UserId: {0} - Name: {1}";
        public static string MSG_USER_UPDATED_ERROR { get; set; } = "Error updating a user";
        public static string MSG_USER_DELETED_SUCCESS { get; set; } = "User deleted - UserId: {0} - Name: {1}";
        public static string MSG_USER_DELETED_ERROR { get; set; } = "Error deleting a user";
        #endregion
    }
}
