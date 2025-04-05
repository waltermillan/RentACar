CREATE TABLE "Users" (
	"id"	INTEGER,
	"name"	TEXT NOT NULL,
	"password"	TEXT NOT NULL,
	"id_rol"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("id_rol") REFERENCES "Roles"("id")
)