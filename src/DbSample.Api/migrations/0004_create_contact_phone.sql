CREATE TABLE contact_phone (
  contact_phone_id INTEGER PRIMARY KEY AUTOINCREMENT,
  contact_id INTEGER NOT NULL,
  phone_number VARCHAR(150) NOT NULL,
  created_at NOT NULL DEFAULT CURRENT_TIMESTAMP,
  modified_at NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (contact_id) REFERENCES contact(contact_id)
)