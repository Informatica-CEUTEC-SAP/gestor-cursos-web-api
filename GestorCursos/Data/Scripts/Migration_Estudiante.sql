CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Estudiantes" (
    "Id" uuid NOT NULL,
    "Nombre" character varying(250) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "FechaNacimiento" date NOT NULL,
    "DepartamentoId" uuid,
    CONSTRAINT "PK_Estudiantes" PRIMARY KEY ("Id")
);

INSERT INTO "Estudiantes" ("Id", "DepartamentoId", "Email", "FechaNacimiento", "Nombre")
VALUES ('1fd151d4-7623-4f7e-b4e9-c72bd313f5be', 'd8bc6149-5282-4f49-87bb-7f02603721f8', 'maria.lopez@example.com', DATE '1995-08-20', 'María López');
INSERT INTO "Estudiantes" ("Id", "DepartamentoId", "Email", "FechaNacimiento", "Nombre")
VALUES ('dcc43a5f-c2a5-431d-9b5f-6d0791fdd3a0', 'bfbd6728-01f4-48f7-850c-eca831b2fb32', 'juan.perez@example.com', DATE '1990-05-15', 'Juan Pérez');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250503021127_AddEstudiante', '9.0.4');

COMMIT;

