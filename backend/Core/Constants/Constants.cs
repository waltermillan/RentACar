namespace Core.Constants
{
    public class Constants
    {
        #region CAR - Entity!
        public static string MSG_CAR_ADDED_SUCCESS { get; set; } = "Automovil dado de alta - Model {0} - Año: {1}";
        public static string MSG_CAR_ADDED_ERROR { get; set; } = "Error al dar de alta un automovil";
        public static string MSG_CAR_UPDATED_ERROR { get; set; } = "Error al actualizar un automovil";
        public static string MSG_CAR_UPDATED_SUCCESS { get; set; } = "Automovil actualizado - Model {0} - Año: {1}";
        public static string MSG_CAR_DELETED_ERROR { get; set; } = "Error al borrar un automovil";
        public static string MSG_CAR_DELETED_SUCCESS { get; set; } = "Automovil borrado - Model {0} - Año: {1}";
        #endregion

        #region CUSTOMER - Emtity!

        public static string MSG_CUSTOMER_ADDED_SUCCESS { get; set; } = "Cliente dado de alta - Nombre {0} - Documento: {1}";
        public static string MSG_CUSTOMER_ADDED_ERROR { get; set; } = "Error al dar de alta un cliente";
        public static string MSG_CUSTOMER_UPDATED_SUCCESS { get; set; } = "Cliente actualizado - Nombre {0} - Documento: {1}";
        public static string MSG_CUSTOMER_UPDATED_ERROR { get; set; } = "Error al actualizar un cliente";
        public static string MSG_CUSTOMER_DELETED_ERROR { get; set; } = "Error al borrar un cliente";
        public static string MSG_CUSTOMER_DELETED_SUCCESS { get; set; } = "Cliente borrado - Nombre {0} - Documento: {1}";

        #endregion

        #region DOCUMENT - Emtity!

        public static string MSG_DOCUMENT_ADDED_SUCCESS { get; set; } = "Documento dado de alta - Descripción: {0}";

        public static string MSG_DOCUMENT_ADDED_ERROR { get; set; } = "Error al dar de alta un documento";
        public static string MSG_DOCUMENT_UPDATED_SUCCESS { get; set; } = "Documento actualizado - Descripción: {0}";
        public static string MSG_DOCUMENT_UPDATED_ERROR { get; set; } = "Error al actualizar un documento";
        public static string MSG_DOCUMENT_DELETED_SUCCESS { get; set; } = "Documento borrado - Descripción: {0}";
        public static string MSG_DOCUMENT_DELETED_ERROR { get; set; } = "Error al borrar un documento";

        #endregion

        #region PAYTYPE - Emtity!

        public static string MSG_PAYTYPE_ADDED_SUCCESS { get; set; } = "tipo de pago dado de alta - Nombre: {0}";

        public static string MSG_PAYTYPE_ADDED_ERROR { get; set; } = "Error al dar de alta un tipo de pago";
        public static string MSG_PAYTYPE_UPDATED_SUCCESS { get; set; } = "tipo de pago actualizado - Nombre: {0}";
        public static string MSG_PAYTYPE_UPDATED_ERROR { get; set; } = "Error al actualizar un tipo de pago";
        public static string MSG_PAYTYPE_DELETED_SUCCESS { get; set; } = "tipo de pago eliminado - Nombre: {0}";
        public static string MSG_PAYTYPE_DELETED_ERROR { get; set; } = "Error al borrar un tipo de pago";

        #endregion

        #region PRICE - Emtity!

        public static string MSG_PRICE_ADDED_SUCESS { get; set; } = "Se ha dado de alta un precio - Valor: {0} - Descuento: {1} - Acepta descuento: {2}";
        public static string MSG_PRICE_ADDED_ERROR { get; set; } = "Error al dar de alta un precio";
        public static string MSG_PRICE_UPDATED_SUCESS { get; set; } = "Se ha actualizado un precio - Valor: {0} - Descuento: {1} - Acepta descuento: {2}";
        public static string MSG_PRICE_UPDATED_ERROR { get; set; } = "Error al actualizar un precio";
        public static string MSG_PRICE_DELETED_SUCESS { get; set; } = "Se ha eliminado un precio - Valor: {0} - Descuento: {1} - Acepta descuento: {2}";
        public static string MSG_PRICE_DELETED_ERROR { get; set; } = "Error al borrar un precio";

        #endregion

        #region RENT - Emtity!

        public static string MSG_RENT_ADDED_SUCCESS { get; set; } = "Se ha dado de alta un alquiler - IdCustomer: {0} - IdCar: {1} - Day: {2} - DayRemaining: {3} - PayTypeId: {4} - PriceId: {5}";
        public static string MSG_RENT_ADDED_ERROR { get; set; } = "Error al dar de alta un alquiler";

        public static string MSG_RENT_UPDATED_SUCCESS { get; set; } = "Se ha dado de alta un alquiler - IdCustomer: {0} - IdCar: {1} - Day: {2} - DayRemaining: {3} - PayTypeId: {4} - PriceId: {5}";
        public static string MSG_RENT_UPDATED_ERROR { get; set; } = "Error al actualizar un alquiler";
        public static string MSG_RENT_DELETED_SUCCESS { get; set; } = "Se ha dado de alta un alquiler - IdCustomer: {0} - IdCar: {1} - Day: {2} - DayRemaining: {3} - PayTypeId: {4} - PriceId: {5}";
        public static string MSGF_RENT_DELETED_ERROR { get; set; } = "Error al borrar un alquiler";

        #endregion
    }
}
