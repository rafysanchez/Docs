[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Delete(Department department)
{
    try
    {
        db.Entry(department).State = EntityState.Deleted;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    catch (DbUpdateConcurrencyException)
    {
        return RedirectToAction("Delete", new { concurrencyError = true, id=department.DepartmentID });
    }
    catch (DataException /* dex */)
    {
        //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
        ModelState.AddModelError(string.Empty, "Unable to delete. Try again, and if the problem persists contact your system administrator.");
        return View(department);
    }
}