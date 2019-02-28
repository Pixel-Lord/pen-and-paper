using Microsoft.AspNetCore.Mvc;
using PenAndPaper.Data;
using PenAndPaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenAndPaper.Controllers.Character
{
  public class CharacterController : Controller
  {
    private readonly ApplicationDbContext _db;

    public CharacterController(ApplicationDbContext db) => _db = db;

    public IActionResult Index()
    {
      //using (_db)
      //{
      return View();
      //return View(_db.Characters.ToList());
      //}
    }

    // Get : Character/Create
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Object character)
    {
      // Überprüft ob das Model in die Datenbank gespeichert werden darf
      if (ModelState.IsValid)
      {
        _db.Add(character);
        await _db.SaveChangesAsync();

        // Zwei optionen
        // 1. return RedirectToAction("Index"); or
        return RedirectToAction(nameof(Index));
      }
      return View(character);
    }

    // Get : Character/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      Object character = null;
      //var character = await _db.Name.SingleOrDefaultAsync(mbox => mbox.Id == id);
      if (character == null)
      {
        return NotFound();
      }
      return View(character);
    }

    // Post : Character/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Object character)
    {
      //if(id != o.Id)
      if (false)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        _db.Update(character);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(character);
    }

    // Get : Character/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      Object character = null;
      //var character = await _db.Name.SingleOrDefaultAsync(mbox => mbox.Id == id);
      if (character == null)
      {
        return NotFound();
      }
      return View(character);
    }

    // Post : Character/Delete/5
    [HttpPost]
    //[HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
      Object character = null;
      //var character = await _db.Name.SingleOrDefaultAsync(mbox => mbox.Id == id);
      //_db.Characters.Remove(character);
      //await _db.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    // Get : Character/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      Object character = null;
      //var character = await _db.Name.SingleOrDefaultAsync(mbox => mbox.Id == id);
      if (character == null)
      {
        return NotFound();
      }
      return View(character);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}