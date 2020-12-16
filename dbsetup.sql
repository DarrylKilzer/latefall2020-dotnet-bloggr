
-- CREATE TABLE profiles (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )


-- CREATE TABLE blogs (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     isPublished TINYINT NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE
-- )

-- CREATE TABLE companies (
--    id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     address VARCHAR(255) NOT NULL, 
--     PRIMARY KEY (id)
-- )



CREATE TABLE companyblogs(
  id INT NOT NULL AUTO_INCREMENT,   
  companyId INT,
  blogId INT,
  creatorId VARCHAR(255) NOT NULL,

  PRIMARY KEY (id),

  FOREIGN KEY (companyId)
  REFERENCES companies (id)
  ON DELETE CASCADE,

  FOREIGN KEY (blogId)
  REFERENCES blogs (id)
  ON DELETE CASCADE,

   FOREIGN KEY (creatorId)
        REFERENCES profiles(id)
        ON DELETE CASCADE

)