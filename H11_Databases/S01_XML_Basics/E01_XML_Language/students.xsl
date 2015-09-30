<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>students</title>
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
      </head>
      <body>
        <table class="table table-striped table-bordered">
          <tr>
            <th>Name</th>
            <th>Gender</th>
            <th>Date of Birth</th>
            <th>Phone</th>
            <th>E-mail</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty#</th>
            <th>Exams</th>
            <th>Enrollment-info</th>
            <th>Teacher-endorsments</th>
          </tr>
          <xsl:for-each select="students/student">
            <tr>
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="sex" />
              </td>
              <td>
                <xsl:value-of select="birthDate" />
              </td>
              <td>
                <xsl:value-of select="phone" />
              </td>
              <td>
                <xsl:value-of select="email" />
              </td>
              <td>
                <xsl:value-of select="course" />
              </td>
              <td>
                <xsl:value-of select="specialty" />
              </td>
              <td>
                <xsl:value-of select="facultyNumber" />
              </td>
              <td>
                <xsl:for-each select="exams/exam">
                  <div>
                    <strong>
                      <xsl:value-of select="name" />
                      <br />
                    </strong>
                    tutor: <xsl:value-of select="tutor" /><br />
                    score: <xsl:value-of select="score" />
                  </div>
                </xsl:for-each>
              </td>
              <td>
                <xsl:for-each select="enrollment-info">
                  <div>
                    Date: <xsl:value-of select="enrollment-date" />
                    <br/>
                    Score: <xsl:value-of select="exam-score" />
                  </div>
                  <br />
                </xsl:for-each>                               
              </td>
              <td>
                <xsl:for-each select="teacher-endorsments">
                  <div>
                    <strong>
                      <xsl:value-of select="teacher-name" />:
                    </strong>
                    <xsl:value-of select="teacher-endorsement" />
                  </div>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>