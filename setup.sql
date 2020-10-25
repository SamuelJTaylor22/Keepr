/* CREATE TABLE vault (
  id int AUTO_INCREMENT,
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  isprivate TINYINT,
  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
    REFERENCES profiles(id)
) */

CREATE TABLE vaultkeep(
  id int AUTO_INCREMENT,
  creatorId VARCHAR(255),
  vaultId int,
  keepId int,
  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
    REFERENCES profiles(id)
    ON DELETE CASCADE,
  FOREIGN KEY (vaultId)
    REFERENCES vault(id)
    ON DELETE CASCADE,
  FOREIGN KEY (keepId)
    REFERENCES keep(id)
    ON DELETE CASCADE
)