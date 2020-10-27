/* CREATE TABLE keeps (
  id int AUTO_INCREMENT,
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  img VARCHAR(255) NOT NULL,
  views int,
  shares int,
  keeps int,
  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
    REFERENCES profiles(id)
) */
/* DROP TABLE vaultkeep;
CREATE TABLE vaultkeeps(
  id int AUTO_INCREMENT,
  creatorId VARCHAR(255),
  vaultId int,
  keepId int,
  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
    REFERENCES profiles(id)
    ON DELETE CASCADE,
  FOREIGN KEY (vaultId)
    REFERENCES vaults(id)
    ON DELETE CASCADE,
  FOREIGN KEY (keepId)
    REFERENCES keeps(id)
    ON DELETE CASCADE
) */

/* ALTER TABLE keeps
ALTER views SET DEFAULT 0;
ALTER shares SET DEFAULT 0;
ALTER keeps SET DEFAULT 0; */
/* DELETE FROM vaults */
SELECT * from profiles;

      /* SELECT keep.*, vk.*
      FROM vaultkeeps vk
      INNER JOIN profiles profile ON vk.creatorId = profile.id
      INNER JOIN keeps keep ON keep.id = vk.keepId
      WHERE vaultId = 116 */