CREATE TABLE "Customers" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT,
	"document"	TEXT,
	"document_type"	INTEGER NOT NULL,
	"birth_date"	TEXT NOT NULL,
	CONSTRAINT "PK_Customer" PRIMARY KEY("id" AUTOINCREMENT)
)