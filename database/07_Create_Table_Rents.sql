CREATE TABLE "Rents" (
	"id"	INTEGER NOT NULL,
	"id_customer"	INTEGER NOT NULL,
	"id_car"	INTEGER NOT NULL,
	"day"	TEXT NOT NULL,
	"day_remaining"	TEXT NOT NULL,
	"pay_type_id"	INTEGER NOT NULL,
	"price_id"	INTEGER NOT NULL,
	CONSTRAINT "PK_Rent" PRIMARY KEY("id" AUTOINCREMENT),
	CONSTRAINT "FK_Rent_Car_id_car" FOREIGN KEY("id_car") REFERENCES "Cars"("id") ON DELETE CASCADE,
	CONSTRAINT "FK_Rent_Customer_id_customer" FOREIGN KEY("id_customer") REFERENCES "Customers"("id") ON DELETE CASCADE
)